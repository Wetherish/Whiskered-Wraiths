namespace PlayerStuff
{
    using UnityEngine;
    using System.Collections;
    using Unity.VisualScripting;
    using Stats;

    public class HealthManager : MonoBehaviour
    {
        [SerializeField] HeroStats heroStats;
        private bool Immune { get; set; }

        public void Heal(int heal)
        {
            if (heroStats.HeroHealth == heroStats.MaxNumberOfHearts * 2)
            {
                return;
            }

            Debug.Log("Heal");
            heroStats.HeroHealth += heal;
        }

        private void ResolveTakeDamage(int damage)
        {
            heroStats.HeroHealth -= damage;
            if (heroStats.HeroHealth <= 0)
            {
                StartCoroutine(Dying());
            }
        }

        public void TakeDamage(int damage)
        {
            if (Immune == false)
            {
                ResolveTakeDamage(1);
                Immune = true;
                StartCoroutine(Waiting());
            }
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(1);
            Immune = false;
        }

        IEnumerator Dying()
        {
            yield return new WaitForNextFrameUnit();
            Immune = false;
            Destroy(gameObject);

        }
    }
}