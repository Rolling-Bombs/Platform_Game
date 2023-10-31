using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/*--Player Controller Script--*/
public class PlayerController : MonoBehaviour
{
    /*--Game Objects--*/
    Rigidbody rigbod; /* This Rigidbody object is initialized to eventually reference 
                    the rigibody of the player from Unity's inspector.*/
    
    /*--Inspector-Visible Variables--*/
    public float speed = 5; /* public (visible in Unity's inspector) float variable,
                    used to influence force amount.*/
    public float jumpMultiplier = 500;

    /*--Private Variables--*/
    private Vector3 playerMovement;
    private Vector3 playerJump;

    void Start()    // Start is called before the first frame update
    {
        rigbod = GetComponent<Rigidbody>(); /* The GetComponent function fetches the 
                    "Rigidbody" component from the player object this script is
                    attached to.*/
    }

    void Update()   // Update is called once per frame
    {
        
    }

    void FixedUpdate() // FixedUpdate is for Physics-based calculations.
    {
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        playerJump = new Vector3(0, Input.GetAxis("Jump"), 0);
        
        rigbod.MovePosition(transform.position + playerMovement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            rigbod.MovePosition(transform.position + playerJump * jumpMultiplier * Time.deltaTime);
        }
    }
}


