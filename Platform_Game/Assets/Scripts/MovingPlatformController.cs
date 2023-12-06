using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    // Variables
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    private int direction = 1;

    private void Update() //Runs once per frame.
    {
        Transform target = GetMovementTarget();
        platform.position = UnityEngine.Vector3.MoveTowards(platform.position, target.position, speed * Time.deltaTime);
        ChangeDirection(target.transform, platform.transform);
    }

    private void ChangeDirection(Transform targetTransform, Transform platformTransform)
    {
        float distance = (platformTransform.position - targetTransform.position).magnitude;

        if(distance <= 0.05f)
        {
            direction *= -1;
        }
        
    }

    private Transform GetMovementTarget() // Returns the transform of the current target.
    {
        if (direction == 1)
        {
            return startPoint.transform;
        }
        else
        {
            return endPoint.transform;
        }
    }


    private void OnDrawGizmos() // Draws lines between the platform and the 2 target points.
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }
}
