using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float bulletSize;
    public LayerMask enemyLayer;
    public int attackDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, bulletSize, enemyLayer);
        foreach (Collider2D collider in hitColliders)
        {
            EnemyDeath enemy = collider.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
                Destroy(gameObject);
            }

        }
    }
}
