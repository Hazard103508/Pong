using UnityEngine;

namespace Pong.Common.Updaters
{
    public class ViewportToWorldPointUpdater : MonoBehaviour
    {
        public Vector2 initPosition;

        void Awake()
        {
            UpdatePosition(initPosition);
        }

        public void UpdatePosition(Vector2 viewportPosition)
        {
            var initPos = Camera.main.ViewportToWorldPoint(new Vector2(viewportPosition.x, viewportPosition.y));
            this.transform.position = new Vector3(initPos.x, initPos.y, 0);
        }
    }
}