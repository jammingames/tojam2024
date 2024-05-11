using System.Collections.Generic;
using UnityEngine;

public class AttachableObject : MonoBehaviour
{

    public List<AttachableJoint> attachableJoints;
    public AttachableJoint currentJoint;
    public Rigidbody rb;

    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (currentJoint == null) currentJoint = attachableJoints[0];
        if (attachableJoints == null) enabled = false;
    }
    
    
    
    public void Attach(AttachableObject otherObj)
    {
        
        //find joint on otherObj
        if (otherObj.currentJoint != null)
        {
            
        }
        
    }

    Vector3 FindPosition(AttachableObject obj)
    {
        Vector3 pos = obj.currentJoint.transform.position;
        //Vector3 newPos =
        return Vector3.zero;
    }
    
    public void Attach(AttachableJoint joint)
    {
        
    }

    public void NextJoint()
    {
        if (attachableJoints.Count > 1)
        {
            int currentIndex = attachableJoints.IndexOf(currentJoint);
            if (currentIndex == attachableJoints.Count - 1)
            {
                currentJoint = attachableJoints[0];
            }
            else if (currentIndex <= attachableJoints.Count - 1)
            {
                currentJoint = attachableJoints[currentIndex + 1];
            }
        }
    }
    
}