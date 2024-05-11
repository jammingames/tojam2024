using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : ScriptableObject
{
    public float force = 5.0f;
    public bool shouldRun = false;
    
}
public class WheelGoZoom : MonoBehaviour
{
    // private CarData data;
    public float torqueSpeed = 5.0f;
    public bool shouldRun = false;
    private Rigidbody rb;
    private void Awake()
    {
        // if (data == null) data = createscrip
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (!shouldRun) return;
        rb.AddTorque(1 * torqueSpeed * Time.fixedDeltaTime, 0,0);
    }
}
