using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public EndlessMove endlessMove;

    public void OnBorderReached(ScreenBorders border)
    {
        if (border == ScreenBorders.Top || border == ScreenBorders.Bottom)
            InvertYDirection();
        else
            InvertXDirection();
    }
    public void OnBallTriggerEnter(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InvertXDirection();
        }
    }

    public void InvertXDirection() => endlessMove.direction.x *= -1;
    public void InvertYDirection() => endlessMove.direction.y *= -1;
}
