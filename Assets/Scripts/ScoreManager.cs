using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int maxScore = 7;
    private int playerScore = 0;
    private int opponentScore = 0;
    private bool isGameOver = false;
    private int winnerIndex = 0; //0 is player, 1 is opponent

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
        if (playerScore >= maxScore)
        {
            isGameOver = true;
            winnerIndex = 0;
        }
    }
    public void increaseOpponentScore(int score)
    {
        opponentScore += score;
        if (opponentScore >= maxScore)
        {
            isGameOver = true;
            winnerIndex = 1;
        }
    }
    public bool GetGameState()
    {
        return isGameOver;
    }
    public int getWinner()
    {
        return winnerIndex;
    }
}
