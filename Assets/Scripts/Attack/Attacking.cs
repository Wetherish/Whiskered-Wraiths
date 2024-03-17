using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] HeroStats heroStats;
    private float lastAttackTime;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Time.time - lastAttackTime >= heroStats.AttackMeleeCooldown || lastAttackTime == 0)
            {
                CheckHit();
                lastAttackTime = Time.time;
                Debug.Log("dmg");
            }
        }
    }
    
  

    void CheckHit()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, heroStats.AttackRange, enemyLayer);
        foreach (Collider2D collider in hitColliders)
        {
            EnemyDeath enemy = collider.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(heroStats.MeleeAttackDamage);
            }

        }
    }
}