namespace Items
{
    using UnityEngine;

    public class Coin : MonoBehaviour
    {
        public int heal = 1;
        private PlayerStuff.PlayerMovement _playerMovement;

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("coin"))
            {
                Destroy(collision.gameObject);
                var gold = GameObject.Find("Canvas").GetComponent<GoldManager>();
                gold.gold++;
            }

            if (collision.gameObject.CompareTag("heal"))
            {
                var hp = GameObject.Find("Hero").GetComponent<PlayerStuff.HealthManager>();
                Destroy(collision.gameObject);
                hp.Heal(heal);
            }
            // Add missing using directive

            if (collision.gameObject.CompareTag("msBuff"))
            {
                _playerMovement = GameObject.Find("Hero").GetComponent<PlayerStuff.PlayerMovement>();
                Destroy(collision.gameObject);
                _playerMovement.MovementSpeedBuff(5f);
            }

            if (collision.gameObject.CompareTag("ProjectileDash"))
            {
                _playerMovement = GameObject.Find("Hero").GetComponent<PlayerStuff.PlayerMovement>();
                Destroy(collision.gameObject);
                _playerMovement.MakeDash<PlayerStuff.Dash.DashProjectile>(); // Fix missing 'Dash' namespace
            }
        }
    }
}