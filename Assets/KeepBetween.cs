using UnityEngine;

public class KeepBetween : MonoBehaviour
{
        
    void Awake()
    {

            DontDestroyOnLoad(gameObject);
    }
}
