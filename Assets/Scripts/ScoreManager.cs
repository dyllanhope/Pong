using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int maxScore = 7;

    [SerializeField] GameObject ballPrefab;

    private int playerScore = 0;
    private int opponentScore = 0;
    private bool isGameOver = false;
    private bool hasWon = false; //0 is player, 1 is opponent
    private GameObject ballInstance;

    EnemyMovement enemyMovement;

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
        ballInstance = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        enemyMovement = FindObjectOfType<EnemyMovement>();
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
        else
        {
            StartCoroutine(StartNewRound());
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
        else
        {
            StartCoroutine(StartNewRound());
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
    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(1);
        Destroy(ballInstance.gameObject);
        ballInstance = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        enemyMovement.FetchNewBallInstance();
    }
}
