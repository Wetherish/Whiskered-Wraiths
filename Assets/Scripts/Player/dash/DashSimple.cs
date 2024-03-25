using System.Collections;
using UnityEngine;

public class DashSimple : Dash
{
    private bool isDashing = false;
    private Rigidbody2D rb;
    private bool canDash;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    public override IEnumerator dash(Vector2 movementDirection, float dashSpeed, float dashTime, float dashCooldown)
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        SimpleDashDebug();
    }
    private void SimpleDashDebug()
    {
        Debug.Log("Simple Dash");
    }

    public override bool IsDashing()
    {
        return isDashing;
    }

    public override bool CanDash()
    {
        return canDash;
    }

}