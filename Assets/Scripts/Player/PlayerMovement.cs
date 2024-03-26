using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private HeroStats heroMovementStats;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private Dash movementDash;
    void Start()
    {
        movementDash = this.gameObject.AddComponent<DashSimple>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (movementDash.IsDashing())
        {
            return;
        }
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && movementDash.CanDash())
        {
            StartCoroutine(movementDash.dash(movementDirection, heroMovementStats.DashSpeed, heroMovementStats.DashTime, heroMovementStats.DashCooldown));
        }
    }
    
    void FixedUpdate()
    {
        if (movementDash.IsDashing())
        {
            return;
        }

        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            rb.velocity = movementDirection * heroMovementStats.MovementSpeed * 1.4f;
        }

        else
        {
            rb.velocity = movementDirection * heroMovementStats.MovementSpeed;
        }
    }
    public void MovementSpeedBuff(float msBuff){
        heroMovementStats.MovementSpeed += msBuff;
    }
    public float getMS()
    {
        return heroMovementStats.MovementSpeed;
    }

    public void makeDashProjectile()
    {
        movementDash = this.gameObject.AddComponent<DashProjectile>();
    }

}