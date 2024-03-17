using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] HeroStats heroMeleDamageStats;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CheckHit();
        }
    }

    void CheckHit()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, heroMeleDamageStats.AttackRange, enemyLayer);
        foreach (Collider2D collider in hitColliders)
        {
            EnemyDeath enemy = collider.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(heroMeleDamageStats.MeleAttackDamage);
            }

        }
    }
}
