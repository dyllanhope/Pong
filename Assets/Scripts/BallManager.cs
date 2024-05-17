using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    private GameObject ballInstance;

    private void Awake()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        if (ballInstance != null)
        {
            Destroy(ballInstance.gameObject);
        }
        ballInstance = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
    }
}
