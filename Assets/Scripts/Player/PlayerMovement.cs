using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Vector2 mousePosition;
    
    [Header("Dash settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashCooldown = 1f;
    bool isDashing = false;
    bool canDash;

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            // Apply diagonal speed multiplier
            rb.velocity = movementDirection * movementSpeed * 1.4f;
        }

        else
        {
            rb.velocity = movementDirection * movementSpeed;
        }
    }
    public void MovementSpeedBuff(float msBuff){
        movementSpeed += msBuff;
    }
    public float getMS()
    {
        return movementSpeed;
    }

}
