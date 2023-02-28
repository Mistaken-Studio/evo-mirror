using System;
using System.Data.Entity;
using HarmonyLib;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Xname.EVO.Database;
using Xname.EVO.Migrations;

namespace Xname.EVO;

internal sealed class Plugin
{
    public static Plugin Instance { get; private set; }

    [PluginConfig]
    public static Config Config = new();

    [PluginPriority(LoadPriority.Medium)]
    [PluginEntryPoint("EVO", "1.0.0", "Bottom text", "Xname")]
    public void Load()
    {
        Instance = this;
        _harmony.PatchAll();
        new StatsCollection();
        try
        {
            System.Data.Entity.Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<EvoDbContext, Configuration>());
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }

        // using var db = new EvoDbContext();
        // Log.Info(db.Achievements.Find(1).RequirementFunc.Invoke(new Stats()
        // {
        //     Escaped = 2
        // }).ToString());
        // Log.Info(db.Achievements.Find(1).RequirementFunc.Invoke(new Stats()
        // {
        //     Escaped = 0
        // }).ToString());
        // var rarity = db.Rarities.Add(new Rarity()
        // {
        //     Name = "Common",
        //     Color = "white"
        //
        // });
        // var rank = db.Ranks.Add(new Rank()
        // {
        //     Name = "Test",
        //     Rarity = rarity,
        //
        // });
        // var achiv = db.Achievements.Add(new Achievement()
        // {
        //     Name = "Test",
        //     Description = "Test",
        //     Rank = rank,
        //     Requirement = "escapes > 1",
        //     Flags = AchievementFlag.ACTIVE
        // });
        // db.SaveChanges();
        AchievementHandler.UpdateAchievements();
    }

    [PluginUnload]
    public void Unload()
    {
        _harmony.UnpatchAll();
    }

    private static readonly Harmony _harmony = new("evo.pl");
}