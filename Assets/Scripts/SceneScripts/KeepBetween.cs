namespace SceneScripts
{
    using UnityEngine;

    public class KeepBetween : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}