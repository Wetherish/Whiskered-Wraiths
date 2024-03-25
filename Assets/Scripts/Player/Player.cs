using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] HeroStats heroStats;
    AttackBase leftClickAttack;
    AttackBase rightClickAttack;

    void Start()
    {
        leftClickAttack = gameObject.AddComponent<AttackRange>();
        rightClickAttack = gameObject.AddComponent<AttackMelee>();
    }

    void Update()
    {
        if (leftClickAttack.IsAttacking())
        {
             if (leftClickAttack.CanAttack()){
                leftClickAttack.Attack();
            }
        }
        if (rightClickAttack.IsAttacking())
        {
            if (rightClickAttack.CanAttack()){
                rightClickAttack.Attack();
            }
            
        }

    }
}