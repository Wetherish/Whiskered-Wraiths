using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Prefab of the projectile to spawn  
    [SerializeField] private Transform firePoint; // Transform where the projectile spawns
    [SerializeField] private Camera virtualCamera;
    [SerializeField] private HeroStats heroStats;
    private float lastAttackTime; // Time of the last attack

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time - lastAttackTime >= heroStats.AttackCooldown || lastAttackTime == 0)
            {
                Shoot();
                lastAttackTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = virtualCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * heroStats.ProjectileSpeed;
    }
}