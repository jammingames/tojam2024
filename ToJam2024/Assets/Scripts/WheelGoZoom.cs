using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WheelGoZoom : MonoBehaviour
{
    // private CarData data;
    public float torqueSpeed = 5.0f;
    public bool shouldRun = false;
    private Rigidbody rb;

    public Vector3 TorqueAxis;
    public float torqueModifier;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (!shouldRun) return;
        rb.AddTorque((torqueSpeed * Time.fixedDeltaTime) * (transform.forward * torqueModifier), ForceMode.Impulse );
    }
}
