using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public List<Rigidbody> rbsInTrigger = new List<Rigidbody>();
    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody collidedRB = other.GetComponent<Rigidbody>();

        if (collidedRB != null)
        {
            if (!rbsInTrigger.Contains(collidedRB))
            {
                rbsInTrigger.Add(collidedRB);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody collidedRB = other.GetComponent<Rigidbody>();

        if (collidedRB != null)
        {
            if (rbsInTrigger.Contains(collidedRB))
            {
                rbsInTrigger.Remove(collidedRB);
            }
        }
    }

    public void Explode()
    {
        foreach (Rigidbody rb in rbsInTrigger)
        {
            rb.AddExplosionForce(explosionForce, transform.position, radius);
        }
    }
    
    
}
