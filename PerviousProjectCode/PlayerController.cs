using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //User Interface. 
    //DO NOT REMOVE
    public Text txtHealth;
    public Text txtLives;
    public Text txtCollectables;

    public float speed = 10;
    public float jumpForce = 10;
    public int health = 100, lives = 3, collectables = 0;

    bool isOnGround = false;
    Vector2 force;
    Rigidbody2D body;

    private Vector3 startPosition;

    void Start()
    {
        force.y = jumpForce;
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        UpdateUI();
        //health and life management
        if (health <= 0)
        {
            lives--;
            health = 100;
        }

        if (lives < 0)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }

        //if the spacebar is released
        //CHANGED TO UP ARROW FOR PERSONAL PREFERENCE
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            //if the player is on the ground
            if (isOnGround)
            {
                //add force to the players rigid body
                body.AddForce(force, ForceMode2D.Impulse);
                isOnGround = false;
            }
        }

        float x = Input.GetAxis("Horizontal");
        //set the players X velocity to x * speed
        //set the players Y velocity to be the current Y velocity
        body.velocity = new Vector2(x * speed, body.velocity.y);

    }

    //DO NOT REMOVE
    void UpdateUI()
    {
        //uncomment the 3 lines of code below when you have your variables defined
        txtHealth.text = "Health: " + health;
        txtLives.text = "Lives: " + lives;
        txtCollectables.text = "Collectables: " + collectables;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (collision.gameObject.tag == "kill")
        {
            health -= 50;
            transform.position = startPosition;
        }

        if (tag == "ground")
        {
            isOnGround = true;
        }
        
        if (collision.gameObject.tag == "door")
        {
            DoorController doorController = collision.gameObject.GetComponent<DoorController>();
            if (collectables >= doorController.requiredCollectables)
            {
                Destroy(collision.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            collectables++;
            Destroy(collision.gameObject);
        }
    }
}
