namespace Bullet
{
    using UnityEngine;
    using PlayerStuff;
    public class CrazyBullet : MonoBehaviour
    {
        [SerializeField] public LayerMask player;
        [SerializeField] public float moveSpeed = 2f;
        [SerializeField] public float acceleration = 0.01f;
        [SerializeField] public float jerk = 0.001f;
        private Vector2 _movement;
        public Transform playerPosition;
        private Rigidbody2D _rb;
        private readonly Collider2D[] _hitColliders = new Collider2D[10];

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckCollisions();
        }

        private void FixedUpdate()
        {
            MoveCharacter(_movement);
        }

        
        private void CheckCollisions()
        {
            int numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, 1, _hitColliders, player);

            for (int i = 0; i < numColliders; i++)
            {
                HealthManager hero = _hitColliders[i].GetComponent<HealthManager>();
                if (hero != null)
                {
                    hero.TakeDamage(1);
                }
            }
        }

       private void MoveCharacter(Vector2 direction)
        {
            acceleration += jerk;
            moveSpeed += acceleration;
            float moveStep = moveSpeed * Time.deltaTime;
            _rb.MovePosition((Vector2)transform.position + (direction * moveStep));
        }

        public void DestroyCrazyBullet()
        {
            Destroy(gameObject);
        }

        public void ThrowAtPlayer()
        {
            Vector3 direction = playerPosition.position - transform.position;
            direction.Normalize();
            _movement = direction;
        }
    }
}