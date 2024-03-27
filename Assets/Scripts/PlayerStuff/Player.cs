namespace PlayerStuff
{
    using UnityEngine;
    using Attack;

    public class Player : MonoBehaviour
    {
        AttackBase _leftClickAttack;
        AttackBase _rightClickAttack;
       
        void Start()
        {
            _leftClickAttack = gameObject.AddComponent<AttackRange>();
            _rightClickAttack = gameObject.AddComponent<AttackMelee>();
        }

        void Update()
        {
            if (_leftClickAttack.IsAttacking())
            {
                if (_leftClickAttack.CanAttack())
                {
                    _leftClickAttack.Attack();
                }
            }

            if (_rightClickAttack.IsAttacking())
            {
                if (_rightClickAttack.CanAttack())
                {
                    _rightClickAttack.Attack();
                }

            }

        }
    }
}