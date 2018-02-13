using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = -10;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
