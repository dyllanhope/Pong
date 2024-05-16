using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int maxScore = 7;

    [SerializeField] GameObject ballPrefab;

    private int playerScore = 0;
    private int opponentScore = 0;
    private bool isGameOver = false;
    private int winnerIndex = 0; //0 is player, 1 is opponent
    private GameObject ballInstance;

    EnemyMovement enemyMovement;

    private void Awake()
    {
        ballInstance = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        enemyMovement = FindObjectOfType<EnemyMovement>();
    }

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
            winnerIndex = 1;
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
    public int getWinner()
    {
        return winnerIndex;
    }
    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(1);
        Destroy(ballInstance.gameObject);
        ballInstance = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        enemyMovement.FetchNewBallInstance();
    }

}
