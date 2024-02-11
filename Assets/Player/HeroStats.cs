using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
     [SerializeField] public int maxHealth = 100;
     [SerializeField] public int currentHealth;
     [SerializeField] public int damage = 10;
     [SerializeField] public float attackSpeed = 1f;
     [SerializeField] public float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Die();
        }
    }

}
