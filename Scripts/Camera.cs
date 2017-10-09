﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
    //Camera BOunds
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Start () {
        player=GameObject.FindGameObjectWithTag("Player");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x,ref velocity.x,smoothTimeX);     //float is smoothed    X position of camera 
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)//If we are at bounds
        {
            //Clamp makes it so transform.positionx is between min and max
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x,maxCameraPos.x),Mathf.Clamp(transform.position.y,minCameraPos.y,maxCameraPos.y),Mathf.Clamp(transform.position.z,minCameraPos.z,maxCameraPos.z));
        }
    }
}
