using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public GameObject projectilePrefab; // Prefab of the projectile to spawn
    public float attackCooldown; // Time between attacks (in seconds)
    public float projectileSpeed; // Speed of the projectile
    public Transform firePoint; // Transform where the projectile spawns
    public Camera VirtualCamera;


    private float lastAttackTime; // Time of the last attack


    void Update()
    {
 
        if (Input.GetKey(KeyCode.Mouse0) & Time.time - lastAttackTime >= attackCooldown)
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
        projectileRigidbody.velocity = direction * projectileSpeed;
    }
}