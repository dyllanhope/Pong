using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winStateText;
    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        bool winState = scoreManager.getWinState();

        if (winState)
        {
            winStateText.text = "YOU WIN!";
        }
        else
        {
            winStateText.text = "YOU LOSE...";
        }
    }
}
