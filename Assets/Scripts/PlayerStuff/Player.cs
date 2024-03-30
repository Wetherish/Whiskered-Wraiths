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
            _leftClickAttack.Attack();
            _rightClickAttack.Attack();
        }
    }
}