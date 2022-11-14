using Pong.Common.Updaters;
using UnityEngine;
using UnityEngine.Events;

namespace Pong.Game
{
    public class PowerUp : MonoBehaviour
    {
        public float speed;
        public ViewportToWorldPointUpdater positionUpdater;

        public UnityEvent onPlayer1Hited;
        public UnityEvent onPlayer2Hited;

        void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        public void ResetPosition()
        {
            float x = Random.Range(0.25f, 0.75f);
            positionUpdater.UpdatePosition(new Vector2(x, 1.1f));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Ball")
            {
                gameObject.SetActive(false);

                var ball = collision.gameObject.GetComponent<BallHandler>();
                if(ball.LastPlayerHited == "Player1")
                    onPlayer1Hited.Invoke();
                else
                    onPlayer2Hited.Invoke();
            }
        }
    }
}