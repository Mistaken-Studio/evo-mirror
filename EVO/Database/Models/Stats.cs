using System.ComponentModel.DataAnnotations;

namespace Xname.EVO;

internal sealed class Stats
{
    [Key]
    public string UserId { get; set; }
    
    public int WarheadStart { get; set; }

    public int WarheadStop { get; set; }

    public int Escaped { get; set; }

    public int PlayedClass0 { get; set; }

    public int PlayedClass1 { get; set; }

    public int PlayedClass2 { get; set; }

    public int PlayedClass3 { get; set; }

    public int PlayedClass4 { get; set; }

    public int PlayedClass5 { get; set; }

    public int PlayedClass6 { get; set; }

    public int PlayedClass7 { get; set; }

    public int PlayedClass8 { get; set; }

    public int PlayedClass9 { get; set; }

    public int PlayedClass10 { get; set; }

    public int PlayedClass11 { get; set; }

    public int PlayedClass12 { get; set; }

    public int PlayedClass13 { get; set; }

    public int PlayedClass15 { get; set; }

    public int PlayedClass16 { get; set; }

    public int PlayedClass17 { get; set; }

    public int PlayedClass18 { get; set; }

    public int PlayedClass19 { get; set; }

    public int PlayedClass20 { get; set; }

    public float TimePlayedClass0 { get; set; }

    public float TimePlayedClass1 { get; set; }

    public float TimePlayedClass2 { get; set; }

    public float TimePlayedClass3 { get; set; }

    public float TimePlayedClass4 { get; set; }

    public float TimePlayedClass5 { get; set; }

    public float TimePlayedClass6 { get; set; }

    public float TimePlayedClass7 { get; set; }

    public float TimePlayedClass8 { get; set; }

    public float TimePlayedClass9 { get; set; }

    public float TimePlayedClass10 { get; set; }

    public float TimePlayedClass11 { get; set; }

    public float TimePlayedClass12 { get; set; }

    public float TimePlayedClass13 { get; set; }

    public float TimePlayedClass15 { get; set; }

    public float TimePlayedClass16 { get; set; }

    public float TimePlayedClass17 { get; set; }

    public float TimePlayedClass18 { get; set; }

    public float TimePlayedClass19 { get; set; }

    public float TimePlayedClass20 { get; set; }

    public int KilledClass0 { get; set; }

    public int KilledClass1 { get; set; }

    public int KilledClass2 { get; set; }

    public int KilledClass3 { get; set; }

    public int KilledClass4 { get; set; }

    public int KilledClass5 { get; set; }

    public int KilledClass6 { get; set; }

    public int KilledClass7 { get; set; }

    public int KilledClass8 { get; set; }

    public int KilledClass9 { get; set; }

    public int KilledClass10 { get; set; }

    public int KilledClass11 { get; set; }

    public int KilledClass12 { get; set; }

    public int KilledClass13 { get; set; }

    public int KilledClass15 { get; set; }

    public int KilledClass16 { get; set; }

    public int KilledClass17 { get; set; }

    public int KilledClass18 { get; set; }

    public int KilledClass19 { get; set; }

    public int KilledClass20 { get; set; }

    public int KilledByDecontamination { get; set; }

    public int KilledByNuke { get; set; }

    public int KilledByFalldown { get; set; }

    public int KilledBySCP207 { get; set; }

    public int KilledBySCP330 { get; set; }

    public int KilledByDisruptor { get; set; }

    public int KilledByJailbird { get; set; }

    public int GeneratorActivated { get; set; }

    public int DamageDoneToSCPS { get; set; }

    public int DamageDone { get; set; }

    public int Used914 { get; set; }

    public int UsedIntercom { get; set; }

    public int UsedMicrohid { get; set; }

    public int Used268 { get; set; }

    public int Used500 { get; set; }

    public int UsedAdrenaline { get; set; }

    public int UsedMedkits { get; set; }

    public int UsedPainkillers { get; set; }

    public int FiredBullets { get; set; }

    public int MissedBullets { get; set; }

    public int Headshots { get; set; }

    public int CuffedPlayers { get; set; }

    public int TimesCuffed { get; set; }

    public int DamageTaken { get; set; }

    public int SCP079Blackouts { get; set; }

    public int SCP079ExpierienceCollected { get; set; }

    public int PocketEscapes { get; set; }

    public int SCP106Captured { get; set; }

    public int SCP049Revived { get; set; }

    public int SCP173NecksSnapped { get; set; }

    public int ItemsPickedUp { get; set; }

    public int Deaths { get; set; }

    public int DoorsOpened { get; set; }

    public int RoundsPlayed { get; set; }

    public int Used207 { get; set; }

    public int Thrown018 { get; set; }

    public int GrenadesThrown { get; set; }

    public int FlashesThrown { get; set; }

    public int SCP079Kills { get; set; }

    public int SCP079Assists { get; set; }

    public int Taken330 { get; set; }

    public int Used330 { get; set; }

    public void AddStats(Stats stats)
    {
        WarheadStart += stats.WarheadStart;
        WarheadStop += stats.WarheadStop;
        Escaped += stats.Escaped;
        PlayedClass0 += stats.PlayedClass0;
        PlayedClass1 += stats.PlayedClass1;
        PlayedClass2 += stats.PlayedClass2;
        PlayedClass3 += stats.PlayedClass3;
        PlayedClass4 += stats.PlayedClass4;
        PlayedClass5 += stats.PlayedClass5;
        PlayedClass6 += stats.PlayedClass6;
        PlayedClass7 += stats.PlayedClass7;
        PlayedClass8 += stats.PlayedClass8;
        PlayedClass9 += stats.PlayedClass9;
        PlayedClass10 += stats.PlayedClass10;
        PlayedClass11 += stats.PlayedClass11;
        PlayedClass12 += stats.PlayedClass12;
        PlayedClass13 += stats.PlayedClass13;
        PlayedClass15 += stats.PlayedClass15;
        PlayedClass16 += stats.PlayedClass16;
        PlayedClass17 += stats.PlayedClass17;
        PlayedClass18 += stats.PlayedClass18;
        PlayedClass19 += stats.PlayedClass19;
        PlayedClass20 += stats.PlayedClass20;
        TimePlayedClass0 += stats.TimePlayedClass0;
        TimePlayedClass1 += stats.TimePlayedClass1;
        TimePlayedClass2 += stats.TimePlayedClass2;
        TimePlayedClass3 += stats.TimePlayedClass3;
        TimePlayedClass4 += stats.TimePlayedClass4;
        TimePlayedClass5 += stats.TimePlayedClass5;
        TimePlayedClass6 += stats.TimePlayedClass6;
        TimePlayedClass7 += stats.TimePlayedClass7;
        TimePlayedClass8 += stats.TimePlayedClass8;
        TimePlayedClass9 += stats.TimePlayedClass9;
        TimePlayedClass10 += stats.TimePlayedClass10;
        TimePlayedClass11 += stats.TimePlayedClass11;
        TimePlayedClass12 += stats.TimePlayedClass12;
        TimePlayedClass13 += stats.TimePlayedClass13;
        TimePlayedClass15 += stats.TimePlayedClass15;
        TimePlayedClass16 += stats.TimePlayedClass16;
        TimePlayedClass17 += stats.TimePlayedClass17;
        TimePlayedClass18 += stats.TimePlayedClass18;
        TimePlayedClass19 += stats.TimePlayedClass19;
        TimePlayedClass20 += stats.TimePlayedClass20;
        KilledClass0 += stats.KilledClass0;
        KilledClass1 += stats.KilledClass1;
        KilledClass2 += stats.KilledClass2;
        KilledClass3 += stats.KilledClass3;
        KilledClass4 += stats.KilledClass4;
        KilledClass5 += stats.KilledClass5;
        KilledClass6 += stats.KilledClass6;
        KilledClass7 += stats.KilledClass7;
        KilledClass8 += stats.KilledClass8;
        KilledClass9 += stats.KilledClass9;
        KilledClass10 += stats.KilledClass10;
        KilledClass11 += stats.KilledClass11;
        KilledClass12 += stats.KilledClass12;
        KilledClass13 += stats.KilledClass13;
        KilledClass15 += stats.KilledClass15;
        KilledClass16 += stats.KilledClass16;
        KilledClass17 += stats.KilledClass17;
        KilledClass18 += stats.KilledClass18;
        KilledClass19 += stats.KilledClass19;
        KilledClass20 += stats.KilledClass20;
        KilledByDecontamination += stats.KilledByDecontamination;
        KilledByNuke += stats.KilledByNuke;
        KilledByFalldown += stats.KilledByFalldown;
        KilledBySCP207 += stats.KilledBySCP207;
        KilledBySCP330 += stats.KilledBySCP330;
        KilledByDisruptor += stats.KilledByDisruptor;
        KilledByJailbird += stats.KilledByJailbird;
        GeneratorActivated += stats.GeneratorActivated;
        DamageDoneToSCPS += stats.DamageDoneToSCPS;
        DamageDone += stats.DamageDone;
        Used914 += stats.Used914;
        UsedIntercom += stats.UsedIntercom;
        UsedMicrohid += stats.UsedMicrohid;
        Used268 += stats.Used268;
        Used500 += stats.Used500;
        UsedAdrenaline += stats.UsedAdrenaline;
        UsedMedkits += stats.UsedMedkits;
        UsedPainkillers += stats.UsedPainkillers;
        FiredBullets += stats.FiredBullets;
        MissedBullets += stats.MissedBullets;
        Headshots += stats.Headshots;
        CuffedPlayers += stats.CuffedPlayers;
        TimesCuffed += stats.TimesCuffed;
        DamageTaken += stats.DamageTaken;
        SCP079Blackouts += stats.SCP079Blackouts;
        SCP079ExpierienceCollected += stats.SCP079ExpierienceCollected;
        PocketEscapes += stats.PocketEscapes;
        SCP106Captured += stats.SCP106Captured;
        SCP049Revived += stats.SCP049Revived;
        SCP173NecksSnapped += stats.SCP173NecksSnapped;
        ItemsPickedUp += stats.ItemsPickedUp;
        Deaths += stats.Deaths;
        DoorsOpened += stats.DoorsOpened;
        RoundsPlayed += stats.RoundsPlayed;
        Used207 += stats.Used207;
        Thrown018 += stats.Thrown018;
        GrenadesThrown += stats.GrenadesThrown;
        FlashesThrown += stats.FlashesThrown;
        SCP079Kills += stats.SCP079Kills;
        SCP079Assists += stats.SCP079Assists;
        Taken330 += stats.Taken330;
        Used330 += stats.Used330;
    }
}
