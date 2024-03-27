namespace Enemy
{
    using UnityEngine;
    using PlayerStuff;
    public class EnemyMain : MonoBehaviour
    {
        [SerializeField] private HealthManager heroHp;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                heroHp.TakeDamage(1);
            }
        }
    }
}