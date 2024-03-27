namespace Enemy
{
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D _rb;
        public float moveSpeed = 5f;
        private Vector2 _movement;


        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            GameObject playerObject = GameObject.FindWithTag("Player");
            player = playerObject.transform;

        }

        void Update()
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            _movement = direction;
        }

        private void FixedUpdate()
        {
            MoveCharacter(_movement);
        }

       void MoveCharacter(Vector2 direction)
{
    _rb.MovePosition((Vector2)transform.position + (direction * (moveSpeed * Time.deltaTime)));
}

    }
}