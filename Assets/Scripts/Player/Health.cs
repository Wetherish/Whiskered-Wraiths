using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumberOfHearts;
    
    public Sprite HeartsFull;
    public Sprite HeartsHalf;
    public Sprite HeartsEmpty;
    public static int maxHealth = 10;
    public Image[] hearts = new Image[maxHealth];
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
                hearts[heartIteraor].sprite = HeartsHalf;
            }
            else if(heartIteraor < health/2)
            {
                hearts[heartIteraor].sprite = HeartsFull;
            } 
            else
            {
                hearts[heartIteraor].sprite = HeartsEmpty;
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
