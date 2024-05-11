using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentData : ScriptableObject
{
    public Transform parent;
    public float Weight;
    public float Durability;
    public float TurnSpeed;
    public float Radius;
    public List<Transform> attachmentPoints;
    public float Acceleration;
    public float FuelConsumption;
    public float FuelCapacity;
    
}

public class AttachmentPoint
{
    public Transform transform;
    public bool isOccupied;
    
    public AttachmentPoint(Transform transform)
    {
        this.transform = transform;
        isOccupied = false;
    }
    
    public void AttachThisTo(AttachmentPoint other)
    {
        
        isOccupied = true;
    }
    
    public void Detach()
    {
        isOccupied = false;
    }
    
    public bool IsOccupied()
    {
        return isOccupied;
    }
    
    public Transform GetTransform()
    {
        return transform;
    }
    
    public void SetTransform(Transform transform)
    {
        this.transform = transform;
    }
}
