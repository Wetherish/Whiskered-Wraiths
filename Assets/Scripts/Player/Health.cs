using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;


public class Health : MonoBehaviour
{
    [SerializeField] HeroStats HPStats;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHearts;
    [SerializeField] private Sprite halfHearts;
    [SerializeField] private Sprite emptyHearts;

    private int maxHealth = 10;

    void Update()
    {
        if (HPStats.MaxNumberOfHearts > maxHealth)
        {
            HPStats.MaxNumberOfHearts = maxHealth;
        }

        if(HPStats.HeroHealth > 2 * HPStats.MaxNumberOfHearts)
        {
            HPStats.HeroHealth = 2 * HPStats.MaxNumberOfHearts;
        }

        for(int heartIteraor = 0; heartIteraor < hearts.Length; heartIteraor++)
        {
            if(HPStats.HeroHealth%2 != 0 && heartIteraor == HPStats.HeroHealth/2)
            {
                hearts[heartIteraor].sprite = halfHearts;
            }
            else if(heartIteraor < HPStats.HeroHealth/2)
            {
                hearts[heartIteraor].sprite = fullHearts;
            } 
            else
            {
                hearts[heartIteraor].sprite = emptyHearts;
            }


            if(heartIteraor < HPStats.MaxNumberOfHearts)
            {
                hearts[heartIteraor].enabled = true;
            }
            else
            {
                hearts[heartIteraor].enabled = false;
            }
        }
    }
    public void Heal(int heal)
    {
        if(HPStats.HeroHealth == maxHealth)
        {
            return;
        }
        HPStats.HeroHealth += heal;
    }
    
    
    public void TakeDamage(int damage)
    {
        HPStats.HeroHealth -= damage;
        if (HPStats.HeroHealth <= 0)
        {
            StartCoroutine(Dying());
            
        }
    }
    
    IEnumerator Dying()
    {
        yield return new WaitForNextFrameUnit();
        HPStats.Immune = false;
        Destroy(gameObject);

    }
    
}

