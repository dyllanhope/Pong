using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject boundary;

    Vector2 minBounds;
    Vector2 maxBounds;

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
        float yPadding = transform.localScale.y / 2;
        yPadding += boundary.transform.localScale.y;

        //Vector2 playerDir = playerInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        //newPos.y = Mathf.Clamp(transform.position.y + playerDir.y, minBounds.y + yPadding, maxBounds.y - yPadding);
        newPos.x = transform.position.x;
        transform.position = newPos;
    }
}
