using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public string SceneToLoad; // Name of the scene to load

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with your player's tag
        {
            Debug.Log("Dupa");
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}