using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRigidbody : MonoBehaviour
{
    public float speed = 5.0f;

    public Vector3 axis = Vector3.up;
    private float input = 0;
    private bool doPhysics = false;
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
            input = Input.GetAxis("Horizontal");
            if (input != 0)
            {
                transform.Rotate(axis, input * speed * Time.deltaTime);    
            }
            
        
        
    }

}
