using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyController : MonoBehaviour
{
    public float directionVer = 1, speedVer = 2;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedVer * directionVer);
        transform.Rotate(0, 0, -10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            directionVer = directionVer * -1;
        }
    }
}
