using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bullet;

    public float spawnTime = 2;
    public float elapsedTime = 0;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            elapsedTime = 0;
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
        }
    }
}
