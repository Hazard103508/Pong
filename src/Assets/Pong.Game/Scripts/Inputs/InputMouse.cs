using Pong.Game.Settings;
using UnityEngine;

namespace Pong.Game.Inputs
{
    public class InputMouse : MonoBehaviour
    {
        private void Awake()
        {
            this.enabled = GameSettings.Input == InputTypes.Mouse;
        }
        void Update()
        {
            if (Time.timeScale > 0)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.transform.position = new Vector3(this.transform.position.x, worldPosition.y, this.transform.position.z);
            }
        }
    }
}