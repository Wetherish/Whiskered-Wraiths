using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int CoinCounter;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            CoinCounter++;
        }

        if (collision.gameObject.CompareTag("heal"))
        {
            Health hp = GameObject.Find("Hero").GetComponent<Health>();
            Destroy(collision.gameObject);
            hp.health++;      
        }

        if (collision.gameObject.CompareTag("msBuff"))
        {
            playerMovement = GameObject.Find("Hero").GetComponent<PlayerMovement>();
            Destroy(collision.gameObject);
            Debug.Log("movementSpeed:" + playerMovement.getMS());
            playerMovement.MovementSpeedBuff(5f);
            Debug.Log("movementSpeed:" + playerMovement.getMS());
        }
    }
}   
