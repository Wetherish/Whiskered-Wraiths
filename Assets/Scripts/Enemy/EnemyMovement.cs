namespace Enemy
{
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D _rb;
        public float moveSpeed = 5f;
        private Vector2 _movement;


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            var playerObject = GameObject.FindWithTag("Player");
            player = playerObject.transform;
        }

        private void Update()
        {
            var direction = player.position - transform.position;
            direction.Normalize();
            _movement = direction;
        }

        private void FixedUpdate()
        {
            MoveCharacter(_movement);
        }

        private void MoveCharacter(Vector2 direction)
        {
            _rb.MovePosition((Vector2)transform.position + direction * (moveSpeed * Time.deltaTime));
        }
    }
}