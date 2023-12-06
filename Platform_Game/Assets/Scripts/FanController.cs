using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FanController : MonoBehaviour
{
    public float fanSpeed = 100.0f;
    void Update() {
        float currentRotation = fanSpeed * Time.deltaTime;
        transform.Rotate(0,0,currentRotation);
    }
}
