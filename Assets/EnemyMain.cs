using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    private bool canTouch = true;
    // Start is called before the first frame update
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
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
            if (canTouch)
            {
                Debug.Log("dmgtaken");
                canTouch = false;
                StartCoroutine(Waiting());
            }


        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        canTouch = true;


    }



}