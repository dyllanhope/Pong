using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        transform.position = Vector2.zero;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 45);
        rb.velocity = transform.up * moveSpeed * Time.deltaTime;
    }
}
