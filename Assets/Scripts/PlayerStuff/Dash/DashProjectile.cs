using System.Collections;
using UnityEngine;
using Stats;
public class DashProjectile : Dash {
    private bool isDashing = false;
    private Rigidbody2D rb;
    private bool canDash;
    private Transform firePoint;
    private Camera virtualCamera;
    private HeroStats heroStats;



    private GameObject projectilePrefab;

    public void Shoot()
    {
        Vector2 mousePosition = virtualCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        direction.Normalize();
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * heroStats.ProjectileSpeed;
    }
    
    void Start()
    {
        projectilePrefab  = GameObject.Find("projectileBullet"); 
        firePoint =  GameObject.Find("Hero").transform;
        virtualCamera = GameObject.Find("Camera").GetComponent<Camera>();
        heroStats = GetComponent<HeroStats>();
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    public override IEnumerator dash(Vector2 movementDirection, float dashSpeed, float dashTime, float dashCooldown)
    {
       
        canDash = false;
        isDashing = true;
        Shoot();
        rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
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