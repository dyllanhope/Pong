using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] bool isPlayerScored = false;
    [SerializeField] int scoreIncrement = 1;

    ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayerScored)
        {
            scoreManager.increaseOpponentScore(scoreIncrement);
        }
        else
        {
            scoreManager.increasePlayerScore(scoreIncrement);
        }
    }
}
