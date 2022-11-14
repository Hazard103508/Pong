using Pong.Common.Behaviours;
using Pong.Common.Helpers;
using UnityEngine;
using UnityEngine.Events;

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                isService = false;

                var sizeY = collision.transform.localScale.y / 2;
                var playerPosY = collision.transform.position.y;

                var hitPointY = this.transform.position.y;
                var relativeHitPointY = hitPointY - playerPosY;
                var hitLocationFactor = Mathf.Clamp(relativeHitPointY / sizeY, -1, 1 );

                float angle = maxAngle * hitLocationFactor;

                var signX = Mathf.Sign(direction.x);
                direction = MathHelpers.DegreeToVector2(angle).normalized * new Vector2(-signX, 1);

                onPlayerHited.Invoke();
            }
        }
    }
}