using System.Collections.Generic;
using UnityEngine;

public class AttachmentManager : MonoBehaviour
{
    public List<AttachableObject> attachableObjects;
    public AttachableObject currentObject;

    public AttachableObject obj1;
    public AttachableObject obj2;

    [ContextMenu("Connect")]
    void ConnectTest()
    {
        Connect(obj1, obj2);
    }
    
    public void Connect(AttachableObject obj, AttachableObject obj2)
    {
        var diff = Quaternion.Inverse(obj.currentJoint.transform.rotation) * obj.transform.rotation;

        var dir2 = Quaternion.LookRotation(obj2.currentJoint.transform.forward * -1);
        obj.transform.rotation = diff * dir2;
        
        Vector3 newPos = obj2.currentJoint.transform.position - (obj.currentJoint.transform.position - obj.transform.position);
        
        obj.transform.position = newPos;
    }
}