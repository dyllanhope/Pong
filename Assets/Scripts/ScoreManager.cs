using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int maxScore = 7;

    private int playerScore = 0;
    private int opponentScore = 0;
    private bool isGameOver = false;
    private bool hasWon = false;

    static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public string getPlayerScore()
    {
        return playerScore.ToString();
    }
    public string getOpponentScore()
    {
        return opponentScore.ToString();
    }
    public void increasePlayerScore(int score)
    {
        playerScore += score;
        if (playerScore >= maxScore)
        {
            isGameOver = true;
            hasWon = true;
        }
    }
    public void increaseOpponentScore(int score)
    {
        opponentScore += score;
        if (opponentScore >= maxScore)
        {
            isGameOver = true;
            hasWon = false;
        }
    }
    public bool GetGameState()
    {
        return isGameOver;
    }
    public bool getWinState()
    {
        return hasWon;
    }
    public void ClearAndRestart()
    {
        playerScore = 0;
        opponentScore = 0;
        isGameOver = false;
        hasWon = false;
    }
}
