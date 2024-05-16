using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI opponentScoreText;

    ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        UpdateScores();
    }
    void UpdateScores()
    {
        playerScoreText.text = scoreManager.getPlayerScore();
        opponentScoreText.text = scoreManager.getOpponentScore();
    }
}
