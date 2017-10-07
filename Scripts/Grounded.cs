using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
    private Player player; // references the script player so we can acess Player
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTrigEnter2d(Collider2D col)//get called when trigger enters something
    {
        player.grounded = true;
    }

    void OnTrigExit2d(Collider2D col)//when trigger exits something
    {
        player.grounded = false;
    }
}
