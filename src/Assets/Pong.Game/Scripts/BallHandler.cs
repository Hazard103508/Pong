using UnityEngine;
using UnityEngine.Events;
using Pong.Common.Behaviours;
using Pong.Common.Helpers;

namespace Pong.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallHandler : MonoBehaviour
    {
        private Vector2 direction;
        private bool isService;
        private float serviceSide;

        public float speed;
        public float maxAngle;
        public UnityEvent onPlayerHited;

        private void Awake()
        {
            serviceSide = Random.value > 0.5f ? 1 : -1;
            ResetBall();
        }
        private void Update()
        {
            float speedFactor = isService ? 0.5f : 1;
            var movement = speed * speedFactor * direction * Time.deltaTime;
            this.transform.Translate(movement);
        }
        public void InvertDirections(ScreenBorders border)
        {
            if (border == ScreenBorders.Top || border == ScreenBorders.Bottom)
                InvertYDirection();
            else
                InvertXDirection();
        }
        public void InvertXDirection() => direction.x *= -1;
        public void InvertYDirection() => direction.y *= -1;
        public void ResetBall()
        {
            transform.position = Vector3.zero;
            isService = true;

            var quarter = new Vector2(serviceSide *= -1, Random.value > 0.5f ? 1 : -1);
            direction = MathHelpers.DegreeToVector2(Random.Range(5, 30)) * quarter;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                direction = (transform.position - collision.transform.position).normalized;
                isService = false;

                Vector2 sign = new Vector2(Mathf.Sign(direction.x), Mathf.Sign(direction.y));
                float currentAngle = Vector3.Angle(Vector3.right * sign, direction);
                if (currentAngle > maxAngle)
                    direction = MathHelpers.DegreeToVector2(maxAngle) * sign;

                onPlayerHited.Invoke();
            }
        }
    }
}