using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 30f;
    public float maxSpeed = 3f;
    public float jumpPower = 150f;

    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator anim;

    //Health or Stats
    public int curHealth;
    public int maxHealth = 100;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();    //Acess rigid body of mcgregor?
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth; //start game w/ max health
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); // Get speed and does stuff  rb2d.velocity.x is actual speed of character

        if (Input.GetAxis("Horizontal") < -0.1f) //Does the flip when walking so if walking in negative direction flips the Ben
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        //Jumping


        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);

        }
        //Limiting curHealth
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        //Check death
        if(curHealth <= 0)
        {
            Die();
        }


    }

    void FixedUpdate()
    {
        //fake friction variables?
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;   //setting ease velocity to current velocity so that there is no friciton in y so we dont get caught on walls
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;  //creating fake friction in x /multiplies the rigidbody x times 0.75 slowing us down


        float h = Input.GetAxis("Horizontal");// The left arrow and right arrow A and D

        //fake friction easing x of player
        if (grounded == true)
        {
            rb2d.velocity = easeVelocity; //setting our current velocity to ease velocity
        }

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h); //move the player spacebar
        //limit speed of player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);// If velocity.x is greater than 30 than we set it equal to vector2 maxspeed
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);// If velocity.x is greater than 30 than we set it equal to vector2 maxspeed
        }

    }
    //Die func
    void Die()
    {
        //future idea death screen
        //we will now just send player to main menu
        SceneManager.LoadScene(1);
    }
}
