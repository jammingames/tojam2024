using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
   public Rigidbody grabbedPointRB;
   public Transform grabPosition; 
   public void Grab(GameObject grabbedObject)
   {
      // SpringJoint springJoint = grabbedObject.AddComponent<SpringJoint>();
      // springJoint.connectedBody = grabbedPointRB;

      float yPos = (grabbedObject.GetComponent<Collider>().bounds.size.y * 0.3f) + grabPosition.position.y;
      grabbedObject.transform.position = new Vector3(grabPosition.position.x, yPos, grabPosition.position.z);
      FixedJoint fixedJoint = grabbedObject.AddComponent<FixedJoint>();
      fixedJoint.connectedBody = grabbedPointRB;

      // grabbedObject.transform.SetParent(gameObject.transform);
   }
}
