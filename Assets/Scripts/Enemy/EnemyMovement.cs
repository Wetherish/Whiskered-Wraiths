using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;

    private Rigidbody2D rb;
    private bool isChasing = false;
    private float distanceToPlayer;
    [SerializeField] private int health;
    [SerializeField] private HealthManager heroHp;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    public float ProjectileSpeed = 2f;
    public GameObject bullet;
    public Transform bulletPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer(distanceToPlayer);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            heroHp.TakeDamage(1);
        }
    }

    public void RangeAttackEnemy()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    void ChasePlayer(float distanceToPlayer)
    {
        Vector2 direction = (player.position - transform.position).normalized;

        if(gameObject.tag == "RangeEnemy")
        {
            if (distanceToPlayer > stoppingDistance)
            {
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                RangeAttackEnemy();
            }
        }
        else
        {
            if (distanceToPlayer > stoppingDistance)
            {
                rb.velocity = direction * moveSpeed;
            }
        }
    }
}
