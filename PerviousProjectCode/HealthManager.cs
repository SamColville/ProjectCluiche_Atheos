using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    int health = 100;
    bool isDead = false;

    public bool doDestroyOtherObjectOnCollision = false;
    public string enemyTag = "Enemy";

    public void Add (int amount)
    {
        health += amount;
    }

    public void Subtract(int amount)
    {
        health -= amount;
    }

    public bool IsDead()
    {
        isDead = health <= 0;
        return isDead;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == enemyTag)
        {
            Subtract(50);
            if (doDestroyOtherObjectOnCollision)
                Destroy(collision.gameObject);
        }
        else if(tag == "health")
        {
            Add(25);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
