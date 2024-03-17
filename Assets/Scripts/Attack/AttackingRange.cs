using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab; // Prefab of the projectile to spawn  
    [SerializeField] private Transform firePoint; // Transform where the projectile spawns
    [SerializeField] private Camera VirtualCamera;
    [SerializeField] private HeroStats heroRangeDamageStats;
    [SerializeField] private float lastAttackTime; // Time of the last attack

    void Update()
    {
 
        if (Input.GetKey(KeyCode.Mouse0) & Time.time - lastAttackTime >= heroRangeDamageStats.AttackCooldown)
        {
            Shoot();
            lastAttackTime = Time.time;
        }
    }
    void Shoot()
    {
        
        Vector2 mousePosition = VirtualCamera.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        direction.Normalize();


        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * heroRangeDamageStats.ProjectileSpeed;
    }
}