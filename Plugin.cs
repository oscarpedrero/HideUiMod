using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using HideUiMod.Patch;
using System.Reflection;

namespace HideUiMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("xyz.molenzwiebel.wetstone")]
    public class Plugin : BasePlugin
    {

        internal static Plugin Instance;
        internal static string Name = PluginInfo.PLUGIN_NAME;
        internal static string Guid = PluginInfo.PLUGIN_GUID;
        internal static string Version = PluginInfo.PLUGIN_VERSION;

        public static ManualLogSource Logger;
        private Harmony _harmony;

        public static ConfigEntry<bool> MiniMapHide;
        public static ConfigEntry<bool> BottomBarHide;
        public static ConfigEntry<bool> RightMenuHide;
        public static ConfigEntry<bool> ClockHide;
        public static ConfigEntry<bool> ChatWindowHide;
        public static ConfigEntry<bool> AllUIHide;


        public override void Load()
        {
            Instance = this;
            Logger = Log;
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            InitConfig();
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            KeyBinds.Initialize();
            KeyBinds.OnKeyPressed += KeyBindPressed.OnKeyPressedOpenPanel;
        }

        private void InitConfig()
        {
            MiniMapHide = Config.Bind("UIHide", "MiniMap", true, "Turn hide minimap on or off");
            BottomBarHide = Config.Bind("UIHide", "BottomBar", true, "Turn hide bottom bar on or off");
            RightMenuHide = Config.Bind("UIHide", "RightMenu", true, "Turn hide right menu on or off");
            ClockHide = Config.Bind("UIHide", "Clock", true, "Turn hide clock on or off");
            ChatWindowHide = Config.Bind("UIHide", "ChatWindow", true, "Turn hide chat window on or off");
            AllUIHide = Config.Bind("UIHide", "AllUI", false, "Enable to hide all UI including player name and health");
        }

    }
}
