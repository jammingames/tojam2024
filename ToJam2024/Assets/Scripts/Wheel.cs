using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : GameComponent
{
    
public Wheel(ComponentData data) : base(data)
    {
        
    }
    
    public void Turn(float turnSpeed)
    {
        Debug.Log($"Wheel is turning {turnSpeed}");
    }
    
    public void Accelerate()
    {
        Debug.Log("Wheel is accelerating");
    }
    
    public void Brake()
    {
        Debug.Log("Wheel is braking");
    }
    
    public void AttachToVehicle()
    {
        Debug.Log("Wheel is attached to vehicle");
    }
    
    public void DetachFromVehicle()
    {
        Debug.Log("Wheel is detached from vehicle");
    }
    
    
}
