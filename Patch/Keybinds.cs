using UnityEngine;
using Bloodstone.API;

namespace HideUiMod.Patch
{
    internal delegate void OnKeyPressedEventHandler(KeyBindFunction keybindFunction);

    internal enum KeyBindFunction
    {
        ToggleUIHideMod
    }

    internal static class KeyBinds
    {
        internal static event OnKeyPressedEventHandler OnKeyPressed;

        private static Keybinding _toggleUiKeyBind;
        private static KeyBindBehaviour _keybindBehavior;

        internal static void Initialize()
        {
            _toggleUiKeyBind = KeybindManager.Register(new()
            {
                Id = Plugin.Guid + "ToggleUI",
                Category = Plugin.Name,
                Name = "Toggle UI",
                DefaultKeybinding = KeyCode.L,
            });
            _keybindBehavior = Plugin.Instance.AddComponent<KeyBindBehaviour>();
        }

        internal static void Uninitialize()
        {
            if (_keybindBehavior != null)
            {
                UnityEngine.Object.Destroy(_keybindBehavior);
            }
        }

        private class KeyBindBehaviour : MonoBehaviour
        {
            private void Update()
            {
                if (_toggleUiKeyBind.IsPressed)
                {
                    OnKeyPressed?.Invoke(KeyBindFunction.ToggleUIHideMod);
                }
            }
        }
    }
}

