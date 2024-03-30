namespace PlayerStuff.Attack
{
    using UnityEngine;
    using Stats;

    public class AttackMelee : AttackBase
    {
        public LayerMask enemyLayer;
        public HeroStats heroStats;
        private float _lastAttackTime;

        private void Awake()
        {
            heroStats = gameObject.GetComponent<HeroStats>();
        }

        public override void Attack()
        {
            if(IsAttacking()){
                if(CanAttack())
                {
                    Debug.Log("Attacking");
                    // Fire();
                }
            }
        }

        private bool IsAttacking()
        {
            return Input.GetKey(KeyCode.Mouse1);
        }

        private bool CanAttack()
        {
            if (Time.time - _lastAttackTime >= heroStats.AttackCooldown || _lastAttackTime == 0) return true;

            return false;
        }
    }
}