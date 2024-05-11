using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent
{
    public Transform transform;
    public List<Transform> availableAttachmentPoints;
    public ComponentData data;
    
    public GameComponent(ComponentData data)
    {
        this.data = data;
    }
    
    public void AttachToPoint(GameComponent attachmentPoint)
    {
        transform.position = attachmentPoint.transform.position;
        transform.rotation = attachmentPoint.transform.rotation;
        transform.parent = attachmentPoint.data.parent;
        Debug.Log("Component is attached to vehicle");
    }

}
