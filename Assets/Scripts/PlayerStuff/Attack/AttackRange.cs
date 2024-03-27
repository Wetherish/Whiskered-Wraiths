namespace PlayerStuff.Attack
{

    using UnityEngine;
    using Stats;

    public class AttackRange : AttackBase
    {
        private GameObject _projectilePrefab;
        private Transform _firePoint;
        private Camera _virtualCamera;
        private HeroStats _heroStats;
        private float _lastAttackTime;

        void Start()
        {
            _projectilePrefab = GameObject.Find("Bullet");
            _firePoint = GameObject.Find("Hero").transform;
            _virtualCamera = GameObject.Find("Camera").GetComponent<Camera>();
            _heroStats = GetComponent<HeroStats>();
        }

        public override void Attack()
        {
            Vector2 mousePosition = _virtualCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePosition - (Vector2)_firePoint.position;
            direction.Normalize();

            GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);

            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = direction * _heroStats.ProjectileSpeed;
        }

        public override bool IsAttacking()
        {
            return Input.GetKey(KeyCode.Mouse0);
        }

        public override bool CanAttack()
        {
            if (Time.time - _lastAttackTime >= _heroStats.AttackCooldown || _lastAttackTime == 0)
            {
                _lastAttackTime = Time.time;
                return true;
            }

            return false;
        }
    }
}