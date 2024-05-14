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

        // Calculate the maximum distance the object can move this frame based on speed limit
        float maxDistance = moveSpeed * Time.deltaTime;

        // Calculate the direction towards the target position
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Calculate the new target position limited by the maximum distance
        Vector2 newTargetPos = (Vector2)transform.position + direction * Mathf.Min(maxDistance, Vector2.Distance(transform.position, targetPosition));

        // Clamp the y position within the bounds
        Vector2 newPos = new Vector2();
        newPos.y = Mathf.Clamp(newTargetPos.y, minBounds.y + yPadding, maxBounds.y - yPadding);
        newPos.x = transform.position.x;

        // Move the object to the new position
        transform.position = newPos;
    }

}
