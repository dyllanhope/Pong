using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0;
    private int opponentScore = 0;
    private bool isGameOver = false;

    public int getPlayerScore()
    {
        return playerScore;
    }
    public int getOpponentScore()
    {
        return opponentScore;
    }
    public void increasePlayerScore(int score)
    {
        playerScore += score;
    }
    public void increaseOpponentScore(int score)
    {
        opponentScore += score;
    }
    public bool getWinState()
    {
        return isGameOver;
    }
}
