using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelGoZoom : MonoBehaviour
{
    public float torqueSpeed = 5.0f;
    public bool shouldRun = false;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (!shouldRun) return;
        rb.AddTorque(1 * torqueSpeed * Time.fixedDeltaTime, 0,0);
    }
}
