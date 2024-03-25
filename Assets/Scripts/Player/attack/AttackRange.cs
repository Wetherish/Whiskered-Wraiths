using UnityEngine;
public class AttackRange : AttackBase
{
    private GameObject projectilePrefab;
    private Transform firePoint;
    private Camera virtualCamera;
    private HeroStats heroStats;
    private float lastAttackTime; 

    void Start()
    {
        projectilePrefab  = GameObject.Find("Bullet"); 
        firePoint =  GameObject.Find("Hero").transform;
        virtualCamera = GameObject.Find("Camera").GetComponent<Camera>();
        heroStats = GetComponent<HeroStats>();
    }

    public override void Attack()
    {        
        Vector2 mousePosition = virtualCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * heroStats.ProjectileSpeed;
    }

    public override bool IsAttacking()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    public override bool CanAttack()
    {
        if (Time.time - lastAttackTime >= heroStats.AttackCooldown || lastAttackTime == 0)
        {
            lastAttackTime = Time.time;
            return true;
        }
        return false;
    }
}