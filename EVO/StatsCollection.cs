using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.MicroHID;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.Usables;
using MapGeneration;
using MapGeneration.Distributors;
using MEC;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp079;
using PlayerRoles.Voice;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using Scp914;
using UnityEngine;

namespace Xname.EVO;

internal sealed class StatsCollection
{
    public static readonly ConcurrentDictionary<string, Stats> PlayerStats = new();

    private static TeslaGate _lastUsedTesla;
    private static Player _scp106;
    private static Player _scp079;

    public StatsCollection()
    {
        EventManager.RegisterEvents(this);
    }

    private static void OnMicroHIDFire(MicroHIDItem item)
    {
        if (item.Owner is not null && PlayerStats.TryGetValue(item.Owner.characterClassManager.UserId, out var value))
            value.UsedMicrohid++;
    }

    [PluginEvent(ServerEventType.WaitingForPlayers)]
    private void OnWaitingForPlayers()
    {
        _scp106 = null;
        _scp079 = null;
        PlayerStats.Clear();
    }

    [PluginEvent(ServerEventType.RoundEnd)]
    private void OnRoundEnd(RoundSummary.LeadingTeam leadingTeam)
    {
        Task.Run(async () =>
        {
            foreach (Player player in Player.GetPlayers())
            {
                if (!PlayerStats.TryGetValue(player.UserId, out var value))
                    continue;

                switch (player.Role)
                {
                    case RoleTypeId.Scp173:
                        value.TimePlayedClass0 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.ClassD:
                        value.TimePlayedClass1 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Spectator:
                        value.TimePlayedClass2 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp106:
                        value.TimePlayedClass3 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.NtfSpecialist:
                        value.TimePlayedClass4 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp049:
                        value.TimePlayedClass5 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scientist:
                        value.TimePlayedClass6 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp079:
                        value.TimePlayedClass7 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.ChaosConscript:
                        value.TimePlayedClass8 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp096:
                        value.TimePlayedClass9 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp0492:
                        value.TimePlayedClass10 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.NtfSergeant:
                        value.TimePlayedClass11 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.NtfCaptain:
                        value.TimePlayedClass12 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.NtfPrivate:
                        value.TimePlayedClass13 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.FacilityGuard:
                        value.TimePlayedClass15 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.Scp939:
                        value.TimePlayedClass16 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.CustomRole:
                        value.TimePlayedClass17 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.ChaosRifleman:
                        value.TimePlayedClass18 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.ChaosRepressor:
                        value.TimePlayedClass19 += player.RoleBase.ActiveTime;
                        break;

                    case RoleTypeId.ChaosMarauder:
                        value.TimePlayedClass20 += player.RoleBase.ActiveTime;
                        break;
                }
            }

            var stats = PlayerStats.ToArray();
            foreach (var stat in stats)
            {
                stat.Value.RoundsPlayed++;
#if DEBUG
                Log.Info($"Statistics for player: {stat.Key}");
                PropertyInfo[] properties = stat.Value.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                    Log.Info($"{propertyInfo.Name} - {propertyInfo.GetValue(stat.Value)}");

                Log.Info("---------------------------------------------------------");
#endif
                stat.Value.UserId = stat.Key;
                await AchievementHandler.SaveStatsAndUnlock(stat.Value);
            }
        });
    }

    [PluginEvent(ServerEventType.PlayerJoined)]
    private void OnPlayerJoined(Player player)
    {
        if (!player.DoNotTrack)
            PlayerStats.TryAdd(player.UserId, new());

        AchievementHandler.RefreshRank(player);
    }

    [PluginEvent(ServerEventType.PlayerLeft)]
    private void OnPlayerLeft(Player player)
    {
        if (player?.UserId is null)
            return;

        if (!PlayerStats.TryGetValue(player.UserId, out var value))
            return;

        switch (player.Role)
        {
            case RoleTypeId.Scp173:
                value.TimePlayedClass0 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.ClassD:
                value.TimePlayedClass1 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Spectator:
                value.TimePlayedClass2 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp106:
                value.TimePlayedClass3 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.NtfSpecialist:
                value.TimePlayedClass4 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp049:
                value.TimePlayedClass5 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scientist:
                value.TimePlayedClass6 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp079:
                value.TimePlayedClass7 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.ChaosConscript:
                value.TimePlayedClass8 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp096:
                value.TimePlayedClass9 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp0492:
                value.TimePlayedClass10 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.NtfSergeant:
                value.TimePlayedClass11 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.NtfCaptain:
                value.TimePlayedClass12 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.NtfPrivate:
                value.TimePlayedClass13 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.FacilityGuard:
                value.TimePlayedClass15 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.Scp939:
                value.TimePlayedClass16 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.CustomRole:
                value.TimePlayedClass17 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.ChaosRifleman:
                value.TimePlayedClass18 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.ChaosRepressor:
                value.TimePlayedClass19 += player.RoleBase.ActiveTime;
                break;

            case RoleTypeId.ChaosMarauder:
                value.TimePlayedClass20 += player.RoleBase.ActiveTime;
                break;
        }
    }

    [PluginEvent(ServerEventType.PlayerChangeRole)]
    private void OnPlayerChangeRole(Player player, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
    {
        if (player is null)
            return;

        if (newRole == RoleTypeId.Scp106)
            _scp106 = player;

        if (reason == RoleChangeReason.RemoteAdmin)
            return;

        Task.Run(() =>
        {
            if (!PlayerStats.TryGetValue(player.UserId, out var value))
                return;

            if (reason == RoleChangeReason.Escaped)
                value.Escaped++;

            switch (newRole)
            {
                case RoleTypeId.Scp173:
                    value.PlayedClass0++;
                    break;

                case RoleTypeId.ClassD:
                    value.PlayedClass1++;
                    break;

                case RoleTypeId.Spectator:
                    value.PlayedClass2++;
                    break;

                case RoleTypeId.Scp106:
                    value.PlayedClass3++;
                    break;

                case RoleTypeId.NtfSpecialist:
                    value.PlayedClass4++;
                    break;

                case RoleTypeId.Scp049:
                    value.PlayedClass5++;
                    break;

                case RoleTypeId.Scientist:
                    value.PlayedClass6++;
                    break;

                case RoleTypeId.Scp079:
                    value.PlayedClass7++;
                    break;

                case RoleTypeId.ChaosConscript:
                    value.PlayedClass8++;
                    break;

                case RoleTypeId.Scp096:
                    value.PlayedClass9++;
                    break;

                case RoleTypeId.Scp0492:
                    value.PlayedClass10++;
                    break;

                case RoleTypeId.NtfSergeant:
                    value.PlayedClass11++;
                    break;

                case RoleTypeId.NtfCaptain:
                    value.PlayedClass12++;
                    break;

                case RoleTypeId.NtfPrivate:
                    value.PlayedClass13++;
                    break;

                case RoleTypeId.FacilityGuard:
                    value.PlayedClass15++;
                    break;

                case RoleTypeId.Scp939:
                    value.PlayedClass16++;
                    break;

                case RoleTypeId.CustomRole:
                    value.PlayedClass17++;
                    break;

                case RoleTypeId.ChaosRifleman:
                    value.PlayedClass18++;
                    break;

                case RoleTypeId.ChaosRepressor:
                    value.PlayedClass19++;
                    break;

                case RoleTypeId.ChaosMarauder:
                    value.PlayedClass20++;
                    break;
            }

            if (oldRole is null)
                return;

            switch (oldRole.RoleTypeId)
            {
                case RoleTypeId.Scp173:
                    value.TimePlayedClass0 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.ClassD:
                    value.TimePlayedClass1 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Spectator:
                    value.TimePlayedClass2 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp106:
                    value.TimePlayedClass3 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.NtfSpecialist:
                    value.TimePlayedClass4 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp049:
                    value.TimePlayedClass5 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scientist:
                    value.TimePlayedClass6 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp079:
                    value.TimePlayedClass7 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.ChaosConscript:
                    value.TimePlayedClass8 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp096:
                    value.TimePlayedClass9 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp0492:
                    value.TimePlayedClass10 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.NtfSergeant:
                    value.TimePlayedClass11 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.NtfCaptain:
                    value.TimePlayedClass12 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.NtfPrivate:
                    value.TimePlayedClass13 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.FacilityGuard:
                    value.TimePlayedClass15 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.Scp939:
                    value.TimePlayedClass16 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.CustomRole:
                    value.TimePlayedClass17 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.ChaosRifleman:
                    value.TimePlayedClass18 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.ChaosRepressor:
                    value.TimePlayedClass19 += oldRole.ActiveTime;
                    break;

                case RoleTypeId.ChaosMarauder:
                    value.TimePlayedClass20 += oldRole.ActiveTime;
                    break;
            }
        });
    }

    [PluginEvent(ServerEventType.PlayerDying)]
    private void OnPlayerDying(Player target, Player attacker, DamageHandlerBase handler)
    {
        Task.Run(() =>
        {
            if (target is not null && PlayerStats.TryGetValue(target.UserId, out var value))
            {
                value.Deaths++;
                if (handler is WarheadDamageHandler)
                    value.KilledByNuke++;
                else if (handler is DisruptorDamageHandler)
                    value.KilledByDisruptor++;
                else if (handler is JailbirdDamageHandler)
                    value.KilledByJailbird++;
                else if (handler is UniversalDamageHandler universalDamageHandler)
                {
                    switch (universalDamageHandler.TranslationId)
                    {
                        case 6:
                            value.KilledByFalldown++;
                            break;

                        case 8:
                            value.KilledByDecontamination++;
                            break;

                        case 10:
                            value.KilledBySCP207++;
                            break;

                        case 11:
                            value.KilledBySCP330++;
                            break;
                    }

                    if (universalDamageHandler.TranslationId == 13 && _lastUsedTesla is not null && PlayerStats.TryGetValue(_scp079.UserId, out value))
                        value.SCP079Kills++;
                }

                if (attacker is not null && PlayerStats.TryGetValue(attacker.UserId, out value))
                {
                    if (attacker.Role == RoleTypeId.Scp173)
                        value.SCP173NecksSnapped++;

                    if (target == attacker)
                        return;

                    switch (target.Role)
                    {
                        case RoleTypeId.Scp173:
                            value.KilledClass0++;
                            break;

                        case RoleTypeId.ClassD:
                            value.KilledClass1++;
                            break;

                        case RoleTypeId.Spectator:
                            value.KilledClass2++;
                            break;

                        case RoleTypeId.Scp106:
                            value.KilledClass3++;
                            break;

                        case RoleTypeId.NtfSpecialist:
                            value.KilledClass4++;
                            break;

                        case RoleTypeId.Scp049:
                            value.KilledClass5++;
                            break;

                        case RoleTypeId.Scientist:
                            value.KilledClass6++;
                            break;

                        case RoleTypeId.Scp079:
                            value.KilledClass7++;
                            break;

                        case RoleTypeId.ChaosConscript:
                            value.KilledClass8++;
                            break;

                        case RoleTypeId.Scp096:
                            value.KilledClass9++;
                            break;

                        case RoleTypeId.Scp0492:
                            value.KilledClass10++;
                            break;

                        case RoleTypeId.NtfSergeant:
                            value.KilledClass11++;
                            break;

                        case RoleTypeId.NtfCaptain:
                            value.KilledClass12++;
                            break;

                        case RoleTypeId.NtfPrivate:
                            value.KilledClass13++;
                            break;

                        case RoleTypeId.FacilityGuard:
                            value.KilledClass15++;
                            break;

                        case RoleTypeId.Scp939:
                            value.KilledClass16++;
                            break;

                        case RoleTypeId.CustomRole:
                            value.KilledClass17++;
                            break;

                        case RoleTypeId.ChaosRifleman:
                            value.KilledClass18++;
                            break;

                        case RoleTypeId.ChaosRepressor:
                            value.KilledClass19++;
                            break;

                        case RoleTypeId.ChaosMarauder:
                            value.KilledClass20++;
                            break;
                    }
                }
            }
        });
    }

    [PluginEvent(ServerEventType.WarheadStart)]
    private void OnWarheadStart(bool isAutomatic, Player player, bool isResumed)
    {
        if (player is not null && !isAutomatic && PlayerStats.TryGetValue(player.UserId, out var value))
            value.WarheadStart++;
    }

    [PluginEvent(ServerEventType.WarheadStop)]
    private void OnWarheadStop(Player player)
    {
        if (player is not null && PlayerStats.TryGetValue(player.UserId, out var value))
            value.WarheadStop++;
    }

    [PluginEvent(ServerEventType.GeneratorActivated)]
    private void OnGeneratorActivated(Scp079Generator generator)
    {
        string logUserID = generator._lastActivator.LogUserID;
        if (logUserID != string.Empty && PlayerStats.TryGetValue(logUserID, out var value))
            value.GeneratorActivated++;
    }

    [PluginEvent(ServerEventType.PlayerDamage)]
    private void OnPlayerDamage(Player target, Player attacker, DamageHandlerBase handler)
    {
        if (handler is not StandardDamageHandler standardDamageHandler)
            return;

        Task.Run(() =>
        {
            if (target is not null && PlayerStats.TryGetValue(target.UserId, out var value))
            {
                value.DamageTaken += Mathf.RoundToInt(standardDamageHandler.Damage);
                if (target != attacker && attacker is not null && PlayerStats.TryGetValue(attacker.UserId, out value))
                {
                    value.DamageDone += Mathf.RoundToInt(standardDamageHandler.Damage);
                    if (target.Team == Team.SCPs)
                        value.DamageDoneToSCPS += Mathf.RoundToInt(standardDamageHandler.Damage);

                    if (handler is FirearmDamageHandler firearmDamageHandler)
                    {
                        value.MissedBullets--;
                        if (firearmDamageHandler.Hitbox == HitboxType.Headshot)
                            value.Headshots++;
                    }
                }
            }
        });
    }

    [PluginEvent(ServerEventType.PlayerUsedItem)]
    private void OnPlayerUsedItem(Player player, ItemBase item)
    {
        if (item is not UsableItem)
            return;

        Task.Run(() =>
        {
            if (!PlayerStats.TryGetValue(player.UserId, out var value))
                return;

            switch (item.ItemTypeId)
            {
                case ItemType.SCP330:
                    value.Used330++;
                    break;

                case ItemType.SCP268:
                    value.Used268++;
                    break;

                case ItemType.SCP207:
                    value.Used207++;
                    break;

                case ItemType.SCP500:
                    value.Used500++;
                    break;

                case ItemType.Adrenaline:
                    value.UsedAdrenaline++;
                    break;

                case ItemType.Medkit:
                    value.UsedMedkits++;
                    break;

                case ItemType.Painkillers:
                    value.UsedPainkillers++;
                    break;
            }
        });
    }

    [PluginEvent(ServerEventType.Scp914Activate)]
    private void OnScp914Activate(Player player, Scp914KnobSetting knobSetting)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.Used914++;
    }

    [PluginEvent(ServerEventType.PlayerShotWeapon)]
    private void OnPlayerShotWeapon(Player player, Firearm firearm)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
        {
            value.MissedBullets++;
            value.FiredBullets++;
        }
    }

    [PluginEvent(ServerEventType.PlayerHandcuff)]
    private void OnPlayerHandcuff(Player cuffer, Player cuffed)
    {
        if (PlayerStats.TryGetValue(cuffed.UserId, out var value))
        {
            value.TimesCuffed++;
            if (cuffer is not null && PlayerStats.TryGetValue(cuffer.UserId, out value))
                value.CuffedPlayers++;
        }
    }

    [PluginEvent(ServerEventType.PlayerInteractScp330)]
    private void OnPlayerInteractScp330(Player player)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.Taken330++;
    }

    [PluginEvent(ServerEventType.Scp079GainExperience)]
    private void OnScp079GainExperience(Player player, int amount, Scp079HudTranslation reason)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
        {
            value.SCP079ExpierienceCollected += amount;
            if (reason >= Scp079HudTranslation.ExpGainTerminationClassD && Scp079HudTranslation.ExpGainWitnessingTermination >= reason)
                value.SCP079Assists++;
        }
    }

    [PluginEvent(ServerEventType.Scp079BlackoutRoom)]
    private void OnScp079BlackoutRoom(Player player, RoomIdentifier room)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.SCP079Blackouts++;
    }

    [PluginEvent(ServerEventType.Scp079BlackoutZone)]
    private void OnScp079BlackoutZone(Player player, FacilityZone zone)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.SCP079Blackouts++;
    }

    [PluginEvent(ServerEventType.PlayerEnterPocketDimension)]
    private void OnPlayerEnterPocketDimension(Player player)
    {
        if (_scp106 is not null && PlayerStats.TryGetValue(_scp106.UserId, out var value))
            value.SCP106Captured++;
    }

    [PluginEvent(ServerEventType.PlayerExitPocketDimension)]
    private void OnPlayerExitPocketDimension(Player player, bool isSuccessful)
    {
        if (isSuccessful && PlayerStats.TryGetValue(player.UserId, out var value))
            value.PocketEscapes++;
    }

    [PluginEvent(ServerEventType.Scp049ResurrectBody)]
    private void OnScp049ResurrectBody(Player player, Player target, BasicRagdoll body)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.SCP049Revived++;
    }

    [PluginEvent(ServerEventType.PlayerSearchedPickup)]
    private void OnPlayerSearchedPickup(Player player, ItemPickupBase pickup)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
            value.ItemsPickedUp++;
    }

    [PluginEvent(ServerEventType.PlayerInteractDoor)]
    private void OnPlayerInteractDoor(Player player, DoorVariant door, bool canOpen)
    {
        if (canOpen && PlayerStats.TryGetValue(player.UserId, out var value))
            value.DoorsOpened++;
    }

    [PluginEvent(ServerEventType.PlayerThrowProjectile)]
    private void OnPlayerThrowProjectile(Player player, ThrowableItem item, ThrowableItem.ProjectileSettings projectileSettings, bool fullForce)
    {
        if (PlayerStats.TryGetValue(player.UserId, out var value))
        {
            switch (item.ItemTypeId)
            {
                case ItemType.GrenadeFlash:
                    value.FlashesThrown++;
                    break;

                case ItemType.GrenadeHE:
                    value.GrenadesThrown++;
                    break;

                case ItemType.SCP018:
                    value.Thrown018++;
                    break;
            }
        }
    }

    [PluginEvent(ServerEventType.Scp079UseTesla)]
    private void OnScp079UseTesla(Player player, TeslaGate tesla)
    {
        _scp079 ??= player;
        _lastUsedTesla = tesla;
        Timing.CallDelayed(1f, () =>
        {
            _lastUsedTesla = null;
        });
    }

    [PluginEvent(ServerEventType.PlayerUsingIntercom)]
    private void OnPlayerUsingIntercom(Player player, IntercomState state)
    {
        if (state == IntercomState.Ready && PlayerStats.TryGetValue(player.UserId, out var value))
            value.UsedIntercom++;
    }

    ~StatsCollection()
    {
        EventManager.UnregisterEvents(this);
    }
}
