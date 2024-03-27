namespace PlayerStuff
{
    using UnityEngine;
    using Attack;

    public class Player : MonoBehaviour
    {
        private AttackBase _leftClickAttack;
        private AttackBase _rightClickAttack;

        private void Start()
        {
            _leftClickAttack = gameObject.AddComponent<AttackRange>();
            _rightClickAttack = gameObject.AddComponent<AttackMelee>();
        }

        private void Update()
        {
            if (_leftClickAttack.IsAttacking())
                if (_leftClickAttack.CanAttack())
                    _leftClickAttack.Attack();

            if (_rightClickAttack.IsAttacking())
                if (_rightClickAttack.CanAttack())
                    _rightClickAttack.Attack();
        }
    }
}