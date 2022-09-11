using HideUiMod.Patch;
using System;
using UnityEngine;

namespace HideUiMod
{
    public class KeyBindPressed
    {
        public static bool UIActive = true;

        public static GameObject allUI = null;
        public static GameObject rightMenu = null;
        public static GameObject miniMap = null;
        public static GameObject bottomBar = null;
        public static GameObject clock = null;
        public static GameObject chatWindow = null;
        private static Vector3 initialPosition;

        internal static void OnKeyPressedOpenPanel(KeyBindFunction keybindFunction)
        {

            if(allUI == null) allUI = GameObject.Find("HUDCanvas(Clone)");
            if(rightMenu == null) rightMenu = GameObject.Find("LinksHUDParent(Clone)");
            if(miniMap == null) miniMap = GameObject.Find("MiniMapParent(Clone)");
            if(clock == null) clock = GameObject.Find("ClockParent3(Clone)");
            if(bottomBar == null) bottomBar = GameObject.Find("BottomBar2(Clone)");
            if (chatWindow == null)
            {
                chatWindow = GameObject.Find("ChatWindow(Clone)");
                initialPosition = chatWindow.transform.position;
            }

            switch (keybindFunction)
            {
                case KeyBindFunction.ToggleUIHideMod:

                    if (UIActive)
                    {
                        UIActive = false;
                        if(Plugin.ChatWindowHide.Value && !Plugin.AllUIHide.Value) chatWindow.transform.position = new Vector2(-50000, -50000);
                    } else
                    {
                        UIActive = true;
                        if (Plugin.ChatWindowHide.Value && !Plugin.AllUIHide.Value) chatWindow.transform.position = initialPosition;
                    }

                    if (Plugin.AllUIHide.Value)
                    {
                        allUI.SetActive(UIActive);
                        break;
                    }

                    if (Plugin.RightMenuHide.Value) rightMenu.SetActive(UIActive);
                    if (Plugin.MiniMapHide.Value) miniMap.SetActive(UIActive);
                    if (Plugin.ClockHide.Value) clock.SetActive(UIActive);
                    if (Plugin.BottomBarHide.Value) bottomBar.SetActive(UIActive);
                    if (Plugin.ChatWindowHide.Value) chatWindow.SetActive(UIActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(keybindFunction), keybindFunction, null);
            }
        }
    }
}
