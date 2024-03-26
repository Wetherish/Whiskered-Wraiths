using UnityEngine;
public class AttackMelee : AttackBase
{
    public LayerMask enemyLayer;
    public HeroStats heroStats;
    private float lastAttackTime;
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
        if (Time.time - lastAttackTime >= heroStats.AttackCooldown  || lastAttackTime == 0)
        {
            return true;
        }
        return false;
    }
}