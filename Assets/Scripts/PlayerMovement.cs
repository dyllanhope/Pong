using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 playerInput;
    void Start()
    {

    }

    void Update()
    {
        MovePlayer();
    }

    private void OnMove(InputValue input)
    {
        playerInput = input.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector2 playerDir = playerInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + playerDir.y);
        transform.position = newPos;
    }
}
