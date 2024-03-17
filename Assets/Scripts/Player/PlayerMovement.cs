using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private HeroStats heroMovementStats;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    bool isDashing = false;
    bool canDash;
    private IEnumerator Dash()
    {
        canDash = false;//dupa
        isDashing = true;
        rb.velocity = new Vector2(movementDirection.x * heroMovementStats.DashSpeed, movementDirection.y * heroMovementStats.DashSpeed);
        yield return new WaitForSeconds(heroMovementStats.DashTime);
        isDashing = false;
        yield return new WaitForSeconds(heroMovementStats.DashCooldown);
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
            rb.velocity = movementDirection * heroMovementStats.MovementSpeed * 1.4f;
        }

        else
        {
            rb.velocity = movementDirection * heroMovementStats.MovementSpeed;
        }
    }
    public void MovementSpeedBuff(float msBuff){
        heroMovementStats.MovementSpeed += msBuff;
    }
    public float getMS()
    {
        return heroMovementStats.MovementSpeed;
    }

}