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
        //need to map out and understand this diff
        var diff = Quaternion.Inverse(obj.currentJoint.transform.rotation) * obj.transform.rotation;
        //vector pointing towards the other attachment point
        var dir2 = Quaternion.LookRotation(obj2.currentJoint.transform.forward * -1);
        obj.transform.rotation = dir2 * diff; //multiplying is order dependent. B local is applied to A global.
        
        Vector3 newPos = obj2.currentJoint.transform.position - (obj.currentJoint.transform.position - obj.transform.position);
        
        obj.transform.position = newPos;
    }
}