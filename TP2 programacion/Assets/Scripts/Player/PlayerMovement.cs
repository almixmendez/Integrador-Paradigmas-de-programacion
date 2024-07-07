using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MOVEMENT")]

    [SerializeField] public float playerSpeed = 10f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] Vector2 movement;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
