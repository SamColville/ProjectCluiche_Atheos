using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyController : MonoBehaviour
{
    public float direction = 1, speed = 2;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, 0);
        transform.Rotate(0, 0, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            direction = direction * -1;
        }
    }
}
