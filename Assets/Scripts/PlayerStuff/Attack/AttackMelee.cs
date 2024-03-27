namespace PlayerStuff.Attack
{
    using UnityEngine;
    using Stats;

    public class AttackMelee : AttackBase
    {
        public LayerMask enemyLayer;
        public HeroStats heroStats;
        private float _lastAttackTime;

        void Awake()
        {
            heroStats = this.gameObject.GetComponent<HeroStats>();
            Debug.Log("HeroStats: " + heroStats.AttackCooldown);
        }

        public override void Attack()
        {
            // throw new System.NotImplementedException();
        }

        public override bool IsAttacking()
        {
            return Input.GetKey(KeyCode.Mouse1);
        }

        public override bool CanAttack()
        {
            if (Time.time - _lastAttackTime >= heroStats.AttackCooldown || _lastAttackTime == 0)
            {
                return true;
            }

            return false;
        }
    }
}