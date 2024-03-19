using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    [SerializeField] private Health health;

    [SerializeField] private HeroStats heroStats;
    [SerializeField] private HealthManager heroHp;
    // Start is called before the first frame update

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            heroHp.TakeDamage(1);
        }
    }

    
}