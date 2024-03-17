using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] private int heroHealth = 10;
    [SerializeField] private int maxNumberOfHearts = 10;


    public bool Immune = false;

    [Header("Movement settings")]
    [SerializeField] private float movementSpeed = 10f;

    [Header("Dash settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashCooldown = 1f;
    
    [Header("Range attack settings")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int rangeAttackDamage;
    [SerializeField] private float bulletSize;
    
    [Header("Melee attack settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float attackMeleeCooldown;
    [SerializeField] private int meleeAttackDamage;
    public int HeroHealth
    {
        get { return heroHealth; }
        set { heroHealth = value; }
    }
    public int MaxNumberOfHearts
    {
        get { return maxNumberOfHearts; }
        set { maxNumberOfHearts = value; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public float DashSpeed
    {
        get { return dashSpeed; }
        set { dashSpeed = value; }
    }

    public float DashTime
    {
        get { return dashTime; }
        set { dashTime = value; }
    }

    public float DashCooldown
    {
        get { return dashCooldown; }
        set { dashCooldown = value; }
    }

    public float AttackCooldown
    {
        get { return attackCooldown; }
        set { attackCooldown = value; }
    }
    
   

    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    public int RangeAttackDamage
    {
        get { return rangeAttackDamage; }
        set { rangeAttackDamage = value; }
    }

    public float BulletSize
    {
        get { return bulletSize; }
        set { bulletSize = value; }
    }
   
    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }

    public int MeleeAttackDamage
    {
        get { return meleeAttackDamage; }
        set { meleeAttackDamage = value; }
    }
    
    public float AttackMeleeCooldown
    {
        get { return attackMeleeCooldown; }
        set { attackCooldown = value; }
    }

}