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
    public static Config Config;

    [PluginPriority(LoadPriority.Medium)]
    [PluginEntryPoint("EVO", "1.0.0", "Bottom text", "Xname")]
    public void Load()
    {
        Instance = this;
        _harmony.PatchAll();
        new StatsCollection();
        System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<EvoDbContext,Configuration>());
        using var db = new EvoDbContext();
        Log.Info("chuj");
        db.Database.CreateIfNotExists();
        Log.Info("chuj1");

        db.Database.Initialize(false);
        Log.Info("chuj2");

        db.EvoStats.Add(new EvoStats()
        {
            UserId = "test",
            WarheadStart = 1,
        });
        Log.Info("chuj3");

        db.SaveChanges();
    }

    [PluginUnload]
    public void Unload()
    {
        _harmony.UnpatchAll();
    }

    private static readonly Harmony _harmony = new("evo.pl");
}