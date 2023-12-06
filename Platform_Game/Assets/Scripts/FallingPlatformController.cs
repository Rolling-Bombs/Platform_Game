using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    public float initialTime = 1.0f;
    private float remainingTime;
    private Rigidbody rb;
    private Boolean startTime = false;
    private Boolean outOfTime = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        remainingTime = initialTime;
    }

    void Update() {
        ReduceTime();
        if (outOfTime == true) {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    void ReduceTime() {
        if(startTime) {
            remainingTime -= Time.deltaTime;
            if(remainingTime <=0) {
                remainingTime = 0;
                startTime = true;
                outOfTime = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player") {
            startTime = true;
        }
    }
}
