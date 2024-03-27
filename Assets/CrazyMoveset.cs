using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyMoveset : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float passiveCooldown;
    [SerializeField] private Transform crazyBody;
    [SerializeField] private float orbLength;
    [SerializeField] private float startShotSpeed;
    [SerializeField] private float jerkShotSpeed;

    private bool _canShoot;
    private readonly List<GameObject> _gameObjects = new List<GameObject>();
    private readonly List<float> _angles = new List<float>();
    private readonly float _spinSpeed = 1f;

    void Update()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            var localGameObject = _gameObjects[i];
            var angle = _angles[i] + _spinSpeed * Time.deltaTime;
            var newPosition = crazyBody.position;
            newPosition.x += 7*Mathf.Cos(angle);
            newPosition.y += 7*Mathf.Sin(angle);
            localGameObject.transform.position = newPosition;
            _angles[i] = angle;
        }

        if (!_canShoot)
        {
            Shoot();
            StartCoroutine(DestroyOrbs());
            StartCoroutine(ResetShoot());
            _canShoot = true;
        }
    }

    IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(passiveCooldown);
        _canShoot = false;
    }

    IEnumerator DestroyOrbs()
    {
        yield return new WaitForSeconds(orbLength);

        foreach (var localGameObject in _gameObjects)
        {
            var bullet = localGameObject.GetComponent<Bullet.CrazyBullet>();
            bullet.moveSpeed = startShotSpeed;
            bullet.acceleration = jerkShotSpeed;
            bullet.ThrowAtPlayer();
            Destroy(localGameObject, 3f);
        }

        _gameObjects.Clear();
        _angles.Clear();
    }

    void Shoot()
    {
        for (int i = 0; i < 10; i++)
        {
            var angle = i * Mathf.PI * 2 / 10;
            var newPosition = crazyBody.position;
            newPosition.x += 7*Mathf.Cos(angle);
            newPosition.y += 7*Mathf.Sin(angle);
            var bullet = Instantiate(enemyBullet, newPosition, Quaternion.identity, crazyBody);
            _gameObjects.Add(bullet);
            _angles.Add(angle);
        }
    }
}