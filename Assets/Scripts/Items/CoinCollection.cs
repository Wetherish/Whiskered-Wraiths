using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int heal = 1;
    PlayerMovement playerMovement;
    public int CoinCounter;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            GoldManager gold = GameObject.Find("Canvas").GetComponent<GoldManager>();
            gold.gold++;
        }

        if (collision.gameObject.CompareTag("heal"))
        {
            HealthManager hp = GameObject.Find("Hero").GetComponent<HealthManager>();
            Destroy(collision.gameObject);
            hp.Heal(heal);      
        }

        if (collision.gameObject.CompareTag("msBuff"))
        {
            playerMovement = GameObject.Find("Hero").GetComponent<PlayerMovement>();
            Destroy(collision.gameObject);
            playerMovement.MovementSpeedBuff(5f);
        }
    }
}   
