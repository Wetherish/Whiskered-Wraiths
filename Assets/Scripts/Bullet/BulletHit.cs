namespace Bullet
{
    using Enemy;
    using Stats;
    using UnityEngine;

    public class BulletHit : MonoBehaviour
    {
        [SerializeField] HeroStats heroRangeDamageStats;
        [SerializeField] public LayerMask enemyLayer;
        
        // Update is called once per frame
        void Update()
        {
            Collider2D[] hitColliders = new Collider2D[10]; // Adjust the size as needed
            int numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, heroRangeDamageStats.BulletSize, hitColliders, enemyLayer);
    
            for (int i = 0; i < numColliders; i++)
            {
                EnemyDeath enemy = hitColliders[i].GetComponent<EnemyDeath>();
                if (enemy != null)
                {
                    enemy.TakeDamage(heroRangeDamageStats.RangeAttackDamage);
                    Destroy(gameObject);
                }
            }
        }
    }
}