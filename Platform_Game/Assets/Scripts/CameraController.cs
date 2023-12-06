using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3 (0,0,0);
    
    void Update()   // Update is called once per frame
    {
        transform.position = target.transform.position + offset;
    }
}
