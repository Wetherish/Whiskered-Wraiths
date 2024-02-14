using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumberOfHearts;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite halfHearts;
    public Sprite emptyHearts;

    private int maxHealth = 10;

    void Update()
    {
        if (NumberOfHearts > maxHealth)
        {
            NumberOfHearts = maxHealth;
        }
        
        if(health > 2 * NumberOfHearts)
        {
            health = 2 * NumberOfHearts;
        }

        for(int heartIteraor = 0; heartIteraor < hearts.Length; heartIteraor++)
        {
            if(health%2 != 0 && heartIteraor == health/2)
            {
                hearts[heartIteraor].sprite = halfHearts;
            }
            else if(heartIteraor < health/2)
            {
                hearts[heartIteraor].sprite = fullHearts;
            } 
            else
            {
                hearts[heartIteraor].sprite = emptyHearts;
            }


            if(heartIteraor < NumberOfHearts)
            {
                hearts[heartIteraor].enabled = true;
            }
            else
            {
                hearts[heartIteraor].enabled = false;
            }
        }
    }
}
