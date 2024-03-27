using System.Collections;
using UnityEngine;

public class DashSimple : Dash
{
    private bool _isDashing;
    private Rigidbody2D _rb;
    private bool canDash;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    public override IEnumerator dash(Vector2 movementDirection, float dashSpeed, float dashTime, float dashCooldown)
    {
        canDash = false;
        _isDashing = true;
        _rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        _isDashing = false;
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
        return _isDashing;
    }

    public override bool CanDash()
    {
        return canDash;
    }

}