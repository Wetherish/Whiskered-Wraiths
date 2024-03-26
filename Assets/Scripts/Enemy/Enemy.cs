using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)     
        {
            Destroy(gameObject);
            
        }
    }
}
