using System.Collections;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    [SerializeField] private Health health;

    [SerializeField] private HeroStats heroStats;
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
            //take dmg
            if (heroStats.Immune == false)
            {
                Debug.Log("dmgTaken");
                health.TakeDamage(1);
                heroStats.Immune = true;
                StartCoroutine(Waiting());
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        heroStats.Immune = false;
    }
}