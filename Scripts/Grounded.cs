using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
    private Player player; // references the script player so we can acess Player
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)//get called when trigger enters something
    {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision) //a function that gets called when a trigger stays on the ground?
    {
        player.grounded = true;

    }

    void OnTriggerExit2D(Collider2D col)//when trigger exits something
    {
        player.grounded = false;
    }
}
