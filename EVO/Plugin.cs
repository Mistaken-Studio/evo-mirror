using HarmonyLib;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

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
    }

    [PluginUnload]
    public void Unload()
    {
        _harmony.UnpatchAll();
    }

    private static readonly Harmony _harmony = new("evo.pl");
}