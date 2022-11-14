using UnityEngine;

namespace Pong.Common.Behaviours
{
    public class ObjectCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Transform parent;

        public void Create()
        {
            var obj = Instantiate(prefab, parent);
        }
    }
}