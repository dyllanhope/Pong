using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] bool isPlayerScored = false;
    [SerializeField] int scoreIncrement = 1;

    ScoreManager scoreManager;
    GameManager gameManager;
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayerScored)
        {
            scoreManager.increaseOpponentScore(scoreIncrement);
            gameManager.StartNewRound();
        }
        else
        {
            scoreManager.increasePlayerScore(scoreIncrement);
            gameManager.StartNewRound();
        }
    }
}
