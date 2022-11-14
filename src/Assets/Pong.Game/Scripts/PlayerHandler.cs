using Pong.Common.Behaviours;
using Pong.Common.Updaters;
using UnityEngine;

namespace Pong.Game
{
    public class PlayerHandler : MonoBehaviour
    {
        private Vector3 initScale;
        public LimitScreenBorders limitScreenBorders;

        private void Awake()
        {
            initScale = transform.localScale;
        }
        public void ApplyPoweUp()
        {
            transform.localScale = new Vector3(initScale.x, initScale.y * 1.2f, initScale.z);
            limitScreenBorders.SetScreenBoundPosition();
        }
        public void RemovePowerUp()
        {
            transform.localScale = initScale;
            limitScreenBorders.SetScreenBoundPosition();
        }
    }
}