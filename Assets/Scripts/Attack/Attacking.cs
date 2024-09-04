using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] HeroStats heroStats;
    private float lastAttackTime;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Time.time - lastAttackTime >= heroStats.AttackMeleeCooldown || lastAttackTime == 0)
            {
                CheckHit();
                lastAttackTime = Time.time;
            }
        }
    }
    
  

    void CheckHit()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, heroStats.AttackRange, enemyLayer);
        foreach (Collider2D collider in hitColliders)
        {
            EnemyMovement enemy = collider.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.TakeDamage(heroStats.MeleeAttackDamage);
            }
        }
    }
}