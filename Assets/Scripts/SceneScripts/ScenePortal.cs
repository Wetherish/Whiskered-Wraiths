namespace SceneScripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PortalTrigger : MonoBehaviour
    {
        public string sceneToLoad; // Name of the scene to load

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) // Replace "Player" with your player's tag
                SceneManager.LoadScene(sceneToLoad);
        }
    }
}