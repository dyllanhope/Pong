using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float coneAngle = 90f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set the initial velocity to move in a random direction within the cone
        rb.velocity = GetRandomDirectionInCone() * moveSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)rb.velocity * Time.fixedDeltaTime;
    }

    private Vector2 GetRandomDirectionInCone()
    {
        // Calculate the angle limits of the cone
        float minAngle = -coneAngle / 2f;
        float maxAngle = coneAngle / 2f;

        // Generate a random angle within the cone range
        float randomAngle = UnityEngine.Random.Range(minAngle, maxAngle);

        // Randomly determine whether to go left or right
        int directionSign = UnityEngine.Random.Range(0, 2) * 2 - 1; // Randomly -1 (left) or 1 (right)

        // Convert the random angle to a direction vector
        Vector2 direction = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;

        return direction.normalized * directionSign;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collision normal
        Vector2 normal = collision.GetContact(0).normal;

        // Reflect the velocity using regular vector reflection formula: v' = v - 2 * (v dot n) * n
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity - 2 * Vector2.Dot(velocity, normal) * normal;
    }

    public Transform GetBallPosition()
    {
        return rb.transform;
    }
}