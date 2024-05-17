using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float endGameWaitTime = 1.5f;
    ScoreManager scoreManager;
    public void StartGame()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        scoreManager.ClearAndRestart();
        SceneManager.LoadScene("GameScene");
    }
    public void EndGame()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(endGameWaitTime);
        SceneManager.LoadScene("EndScene");
    }
}
