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
        //Quaternion.Angle()
        var dir1 = obj.transform.forward + obj.currentJoint.transform.forward;
        var dir2 = obj2.currentJoint.transform.forward * -1;
        var direction =
            obj.transform.rotation = Quaternion.LookRotation(dir1 -dir2);
        
        Vector3 newPos = obj2.currentJoint.transform.position - (obj.currentJoint.transform.position - obj.transform.position);
        
        obj.transform.position = newPos;
    }
}