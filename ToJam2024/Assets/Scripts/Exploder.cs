using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public List<Rigidbody> rbsInTrigger = new List<Rigidbody>();
    public List<ObstacleBehaviour> obstaclesInTrigger = new List<ObstacleBehaviour>();
    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody collidedRB = other.GetComponent<Rigidbody>();
        ObstacleBehaviour collidedObstacle = other.GetComponent<ObstacleBehaviour>();

        if (collidedRB != null)
        {
            if (!rbsInTrigger.Contains(collidedRB))
            {
                rbsInTrigger.Add(collidedRB);
            }
        }
        if (collidedObstacle != null)
        {
            if (!obstaclesInTrigger.Contains(collidedObstacle))
            {
                obstaclesInTrigger.Add(collidedObstacle);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody collidedRB = other.GetComponent<Rigidbody>();
        ObstacleBehaviour collidedObstacle = other.GetComponent<ObstacleBehaviour>();

        if (collidedRB != null)
        {
            if (rbsInTrigger.Contains(collidedRB))
            {
                rbsInTrigger.Remove(collidedRB);
            }
        }
        if (collidedObstacle != null)
        {
            if (!obstaclesInTrigger.Contains(collidedObstacle))
            {
                obstaclesInTrigger.Add(collidedObstacle);
            }
            
        }
    }

    public void Explode()
    {
        foreach (ObstacleBehaviour obstacle  in obstaclesInTrigger)
        {
            obstacle.ReduceMass();
        }
        
        foreach (Rigidbody rb in rbsInTrigger)
        {
            rb.AddExplosionForce(explosionForce, transform.position, radius);
        }
    }
    
    
}
