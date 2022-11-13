using UnityEngine;

namespace Pong.Game.Inputs
{
    public class InputKeyboard : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            float factor = Input.GetAxisRaw("Vertical");
            var y = speed * factor * Time.deltaTime;
            this.transform.Translate(Vector3.up * y);
        }
    }
}