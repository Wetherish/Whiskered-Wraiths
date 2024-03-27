namespace PlayerStuff
{

    using UnityEngine;
    using Stats;
 
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private HeroStats heroMovementStats;
        private Rigidbody2D _rb;
        private Vector2 _movementDirection;

        private Dash _movementDash;

        void Start()
        {
            _movementDash = this.gameObject.AddComponent<DashSimple>();
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_movementDash.IsDashing())
            {
                return;
            }

            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && _movementDash.CanDash())
            {
                StartCoroutine(_movementDash.dash(_movementDirection, heroMovementStats.DashSpeed,
                    heroMovementStats.DashTime, heroMovementStats.DashCooldown));
            }
        }

        void FixedUpdate()
        {
            if (_movementDash.IsDashing())
            {
                return;
            }

            if (_movementDirection.x != 0 && _movementDirection.y != 0)
            {
                _rb.velocity = _movementDirection * heroMovementStats.MovementSpeed * 1.4f;
            }

            else
            {
                _rb.velocity = _movementDirection * heroMovementStats.MovementSpeed;
            }
        }

        public void MovementSpeedBuff(float msBuff)
        {
            heroMovementStats.MovementSpeed += msBuff;
        }

        public float GetMS()
        {
            return heroMovementStats.MovementSpeed;
        }

        public void MakeDashProjectile()
        {
            _movementDash = this.gameObject.AddComponent<DashProjectile>();
        }

    }
}