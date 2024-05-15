using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject boundary;

    Vector2 minBounds;
    Vector2 maxBounds;

    BallMovement ballMovement;

    private void Awake()
    {
        ballMovement = FindObjectOfType<BallMovement>();
    }
    void Start()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Transform ballTransform = ballMovement.GetBallPosition();
        float yPadding = transform.localScale.y / 2;
        yPadding += boundary.transform.localScale.y;

        float targetPointY = ballTransform.position.y;
        Vector2 targetPosition = new Vector2(transform.position.x, targetPointY);

        //Vector2 playerDir = playerInput * moveSpeed * Time.deltaTime;
        Vector2 newTargetPos = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        Vector2 newPos = new Vector2();
        newPos.y = Mathf.Clamp(newTargetPos.y, minBounds.y + yPadding, maxBounds.y - yPadding);
        newPos.x = transform.position.x;
        transform.position = newPos;
    }
}
