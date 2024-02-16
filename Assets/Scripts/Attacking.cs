using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
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
        Debug.Log("Attack");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        Debug.Log($"{hitColliders.Length} colliders");
        foreach (Collider2D collider in hitColliders)
        {
            Debug.Log("uwu");
            EnemyDeath enemy = collider.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("DostajeDMG");
            }

        }
    }
}
