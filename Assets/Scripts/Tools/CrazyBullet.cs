using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBullet : MonoBehaviour
{
    [SerializeField] public LayerMask Player; 
    private Vector2 movement;
    public Transform playerPosition;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1, Player);
        
        foreach (Collider2D collider in hitColliders)
        {
            HealthManager hero = collider.GetComponent<HealthManager>();
            if (hero != null)
            {
                hero.TakeDamage(1);
            }

        }
        
        Vector3 direction = playerPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        
    }
    
    public void OneTimeGoing()
    {
        ThrowAtPlayer();
        moveCharacter(movement);
    }
    
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
    public void DestroyCrazyBullet()
    {
        Destroy(gameObject);
    }

    void ThrowAtPlayer()
    {
        Vector3 direction = playerPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }
    
}
