using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] HeroStats heroRangeDamageStats;
    [SerializeField] public LayerMask enemyLayer;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, heroRangeDamageStats.BulletSize, enemyLayer);
        foreach (Collider2D collider in hitColliders)
        {
            EnemyDeath enemy = collider.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(heroRangeDamageStats.RangeAttackDamage);
                Destroy(gameObject);
            }

        }
    }
}
