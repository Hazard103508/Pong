using Pong.Game.Settings;
using UnityEngine;

namespace Pong.Game.Inputs
{
    public class InputKeyboard : MonoBehaviour
    {
        public float speed;

        private void Awake()
        {
            this.enabled = GameSettings.Input == InputTypes.Keyboard;
        }
        void Update()
        {
            float factor = Input.GetAxisRaw("Vertical");
            var y = speed * factor * Time.deltaTime;
            this.transform.Translate(Vector3.up * y);
        }
    }
}