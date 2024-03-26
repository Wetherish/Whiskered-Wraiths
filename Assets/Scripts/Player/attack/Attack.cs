using UnityEngine;
public abstract class AttackBase: MonoBehaviour{
    public abstract void Attack();
    public abstract bool IsAttacking();
    public abstract bool CanAttack();
}