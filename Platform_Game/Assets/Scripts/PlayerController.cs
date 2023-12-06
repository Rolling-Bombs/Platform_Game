using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /*  Player Controller Script
         - Controls player movement
         - Tracks time
         - Checks for falls
         - Determines win/loss
    */

    private Rigidbody rb;
    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    private float jumpMovement;
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private double remainingTime;
    public float initialTime = 10.0f;
    private bool stopTime = false;
    private bool goalReached = false;
    public TMP_Text timerText;
    public TMP_Text finalText;
    public TMP_Text restartText;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Gets a reference to Rigidbody component.
        ApplyConstraints(); //Prevents the player from moving in an undesired direction/rotation.

        remainingTime = initialTime; //Sets the in-game timer to the time given in the inspector.
    }
    void Update()
    {
        ReduceTime(); //reduces the timer by the time elapsed in the game.
        JumpCheck(); //checks to see if the jump button is being pressed.
        InputCheck(); //checks for input on the "Horizontal" controller axis.
        FallCheck(); //checks to see if you fell, lol.
        GameOver(); //checks to see if the time stopped, ending the game.
    }
    void FixedUpdate()
    {
        rb.AddForce(horizontalMovement * Time.deltaTime); //applies force on x axis to move player
        rb.AddForce(verticalMovement * Time.deltaTime); //applies upwards force if player is jumping
    }

    void ApplyConstraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
        RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    void ReduceTime()
    {
        if(!stopTime)
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime <=0)
            {
                remainingTime = 0;
                stopTime = true;
            }
        }
        UpdateTimerText();
    }
    void UpdateTimerText()
    {
        timerText.text = "Remaining Time(sec): " + Math.Round(remainingTime, 2).ToString();
    }
    void JumpCheck()
    {
        if(!stopTime)
        {
            if(Input.GetButtonDown("Jump"))
                jumpMovement = 1;
            else
                jumpMovement = 0;
        
            verticalMovement = new Vector3(0, jumpMovement * jumpForce, 0);
        }
    }
    void InputCheck()
    {
        if (!stopTime) {
            horizontalMovement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
        }
    }
    void FallCheck()
    {
        if (transform.position.y < -10)
            stopTime = true;
    }
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Goal") {
            goalReached = true;
            stopTime = true;
        }
    } 
    void GameOver()
    {
        if(stopTime)
        {
            if(goalReached)
                finalText.text = "You Win!";
            else
                finalText.text = "You Lose";

            finalText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
        }
    }
}
