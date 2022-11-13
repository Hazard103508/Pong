using UnityEngine;
using UnityEngine.Events;

namespace Pong.Common.Behaviours
{
    public class HotkeyPressed : MonoBehaviour
    {
        public KeyCode key;
        public UnityEvent onHotKeyPressed;

        void Update()
        {
            if (Input.GetKeyDown(key))
                onHotKeyPressed.Invoke();
        }
    }
}