using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float lowMass = 5;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void ReduceMass()
    {
        rb.mass = lowMass;
    }
}
