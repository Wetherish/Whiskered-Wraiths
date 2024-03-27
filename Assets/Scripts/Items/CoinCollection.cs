namespace Items
{
    using UnityEngine;
    using PlayerStuff;
    
    public class Coin : MonoBehaviour
    {
        public int heal = 1;
        PlayerMovement _playerMovement;
        
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("coin"))
            {
                Destroy(collision.gameObject);
                GoldManager gold = GameObject.Find("Canvas").GetComponent<GoldManager>();
                gold.gold++;
            }

            if (collision.gameObject.CompareTag("heal"))
            {
                HealthManager hp = GameObject.Find("Hero").GetComponent<HealthManager>();
                Destroy(collision.gameObject);
                hp.Heal(heal);
            }


            if (collision.gameObject.CompareTag("msBuff"))
            {
                _playerMovement = GameObject.Find("Hero").GetComponent<PlayerMovement>();
                Destroy(collision.gameObject);
                _playerMovement.MovementSpeedBuff(5f);
            }

            if (collision.gameObject.CompareTag("ProjectileDash"))
            {
                _playerMovement = GameObject.Find("Hero").GetComponent<PlayerMovement>();
                Destroy(collision.gameObject);
                Debug.Log("DashProjectile");
                _playerMovement.MakeDashProjectile();
            }

        }
    }
}