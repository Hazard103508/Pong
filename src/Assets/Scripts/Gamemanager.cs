using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Scores scores;
    public BallHandler ballHandler;
    public Player player1;
    public Player player2;

    public void OnBorderOutReached(ScreenBorders screenBorders)
    {
        if (screenBorders == ScreenBorders.Left)
        {
            player1.score++;
            scores.RefreshScorePlayer1(player1.score);
        }
        else if (screenBorders == ScreenBorders.Right)
        {
            player2.score++;
            scores.RefreshScorePlayer2(player2.score);
        }

        ballHandler.ResetBall();
    }
}
