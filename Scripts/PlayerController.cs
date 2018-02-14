using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    public int health = 100, keys = 0, floppyDiscs = 0;//Number of floppies to determine what text is available to read.
    public int jumpNumber = 0;//for double jump later

    bool isOnGround = false;//for jumpie jumps.
    Vector2 force;
    Rigidbody2D body;

    private Vector3 startPosition;//change to hub or begining of level? When health = 0.


    // Use this for initialization
    void Start ()
    {
        force.y = jumpForce;
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;//amend for Hub position?		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health<0)
        {//choose position of respawn. Hub or checkpoint in game.
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                body.AddForce(force, ForceMode2D.Impulse);
                isOnGround = false;
                jumpNumber++;//added for double jump mechanics later.
            }
        }

        float xDirection = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(x * speed, body.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        //Reaper damage
        if (collision.gameObject.tag == "reaper")
        {
            health -= 20;
        }

        if (tag =="ground")
        {
            isOnGround = true;
        }

    }

    private void OnTriggerEnter20(Collider2D collision)
    {
        if (collision.gameObject.tag == "floppy")
        {
            floppyDiscs++;
        }
        else if (collision.gameObject.tag == "key")
        {
            keys++;
        }
    }
}
