using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    
    void FixedUpdate()
    {
        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            // Apply diagonal speed multiplier
            rb.velocity = movementDirection * movementSpeed * 1.3f;
        }
        else
        {
            rb.velocity = movementDirection * movementSpeed;
        }
    }
}
