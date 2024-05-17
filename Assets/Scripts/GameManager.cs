using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    EnemyMovement enemyMovement;
    BallManager ballManager;
    ScoreManager scoreManager;
    LevelManager levelManager;

    private void Awake()
    {
        enemyMovement = FindObjectOfType<EnemyMovement>();
        ballManager = FindObjectOfType<BallManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void StartNewRound()
    {
        if (scoreManager.GetGameState())
        {
            levelManager.EndGame();
        }
        else
        {
            StartCoroutine(ResetRound());
        }
    }
    private IEnumerator ResetRound()
    {
        yield return new WaitForSeconds(1);
        ballManager.SpawnBall();
        enemyMovement.FetchNewBallInstance();
    }
}
