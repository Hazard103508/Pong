using UnityEngine;
using UnityEngine.Events;

public class Gamemanager : MonoBehaviour
{
    private int scorePS1;
    private int scorePS2;
    public int maxScore;

    public UnityEvent<int> onPlayer1ScoreChanged;
    public UnityEvent<int> onPlayer2ScoreChanged;
    public UnityEvent onLoseGame;
    public UnityEvent onWinGame;

    public void IncreaseScore(ScreenBorders screenBorders)
    {
        if (screenBorders == ScreenBorders.Left)
        {
            scorePS1++;
            onPlayer1ScoreChanged.Invoke(scorePS1);
        }
        else if (screenBorders == ScreenBorders.Right)
        {
            scorePS2++;
            onPlayer2ScoreChanged.Invoke(scorePS2);
        }

        if (scorePS1 >= maxScore)
            onWinGame.Invoke();
        else if (scorePS2 >= maxScore)
            onLoseGame.Invoke();
    }
    public void ResetScore()
    {
        scorePS1 = 0;
        scorePS2 = 0;

        onPlayer1ScoreChanged.Invoke(scorePS1);
        onPlayer2ScoreChanged.Invoke(scorePS2);
    }
}
