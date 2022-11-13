using UnityEngine;

namespace Pong.Game.Inputs
{
    public class InputMouse : MonoBehaviour
    {
        void Update()
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(this.transform.position.x, worldPosition.y, this.transform.position.z);
        }
    }
}