using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text labelScorePlayer1;
    public Text labelScorePlayer2;

    public void RefreshScorePlayer1(int value)
    {
        RefreshScore(labelScorePlayer1, value);
    }
    public void RefreshScorePlayer2(int value)
    {
        RefreshScore(labelScorePlayer2, value);
    }
    private void RefreshScore(Text label, int value)
    {
        label.text = value.ToString();
    }
}
