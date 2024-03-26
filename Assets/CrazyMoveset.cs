using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyMoveset : MonoBehaviour
{
    private float radius = 7;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float PassiveCooldown;
    [SerializeField] private Transform crazyBody;
    private bool crazyCanShoot = false;
    [SerializeField] private CrazyBullet CrazyBullet;
    [SerializeField] private float OrbLength;
    public List<GameObject> gameObjects;
    private List<float> angles;
    private float spinSpeed = 1f;
    
    void Start()
    {
        angles = new List<float>();  
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject gameObject = gameObjects[i];
            float angle = angles[i] + spinSpeed * Time.deltaTime; // Increment the angle
            Vector3 newPosition = crazyBody.position;
            newPosition.x += radius * Mathf.Cos(angle);
            newPosition.y += radius * Mathf.Sin(angle);
            gameObject.transform.position = newPosition;
            angles[i] = angle; // Store the updated angle
        }
        
        if (crazyCanShoot == false)
        {
            CrazyShoot();
            StartCoroutine(AurelionDestroyOrbs());
            StartCoroutine(AurelionSol());
            crazyCanShoot = true;
 
        }
    }
    
    IEnumerator AurelionSol()
    {
            yield return new WaitForSeconds(PassiveCooldown);
            crazyCanShoot = false;
    }
    
    IEnumerator AurelionDestroyOrbs()
    {
        yield return new WaitForSeconds(OrbLength);
        foreach (GameObject Kulka in gameObjects)
        {
            //CrazyBullet.OneTimeGoing();
            Kulka.GetComponent<CrazyBullet>().OneTimeGoing();
        }
        gameObjects.Clear(); 
        angles.Clear(); 
    }
    
    void CrazyShoot()
    { 
        float radius = 7; // The radius of the circle
        for (int j = 0; j < 10; j++)
        {
            float angle = j * Mathf.PI * 2 / 10; // Divide the circle into 10 parts
            Vector3 newPosition = crazyBody.position;
            newPosition.x += radius * Mathf.Cos(angle);
            newPosition.y += radius * Mathf.Sin(angle);
            gameObjects.Add(Instantiate(enemyBullet, newPosition, crazyBody.rotation, crazyBody));
            angles.Add(angle); // Store the initial angle
        }
    }

}
