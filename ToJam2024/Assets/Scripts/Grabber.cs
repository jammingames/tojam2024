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

      grabbedObject.transform.position = grabPosition.position;
      FixedJoint fixedJoint = grabbedObject.AddComponent<FixedJoint>();
      fixedJoint.connectedBody = grabbedPointRB;

      // grabbedObject.transform.SetParent(gameObject.transform);
   }
}
