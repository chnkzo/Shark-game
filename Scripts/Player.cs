using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 50f;
    public float maxSpeed = 1;
    public float jumpPower = 150f;

    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();    //Acess rigid body of mcgregor?
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); // Get speed and does stuff

        if(Input.GetAxis("Horizontal")<-0.1f) //Does the flip when walking so if walking in negative direction flips the Ben
            {
            transform.localScale = new Vector3(-1, 1, 1);
            }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Jumping


            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                rb2d.AddForce(Vector2.up * jumpPower);

            }


    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");// The left arrow and right arrow A and D
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
}
