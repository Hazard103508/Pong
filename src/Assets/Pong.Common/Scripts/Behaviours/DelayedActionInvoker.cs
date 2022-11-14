using UnityEngine;
using UnityEngine.Events;

namespace Pong.Common.Behaviours
{
    public class DelayedActionInvoker : MonoBehaviour
    {
        public float delayStartTimeSeconds;
        public float minTimeSeconds;
        public float maxTimeSeconds;

        public UnityEvent onActionStart;

        void Start()
        {
            Invoke("RunAction", delayStartTimeSeconds);
        }

        private void RunAction()
        {
            onActionStart.Invoke();
            float delay = Random.Range(minTimeSeconds, maxTimeSeconds);
            Invoke("RunAction", delay);
        }
    }
}