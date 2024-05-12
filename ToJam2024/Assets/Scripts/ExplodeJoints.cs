using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ExplodeJoints : MonoBehaviour
{
    public float delay = 0.5f;
    public float explosiveForce = 5000;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        DoExplodeJoints();
    }

    void DoExplodeJoints()
    {
        var joints = GetComponentsInChildren<Joint>();
        foreach (Joint joint in joints)
        {
            joint.connectedBody = null;
            Destroy(joint);
        }

        foreach (var rb in GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = UnityEngine.Random.insideUnitSphere * explosiveForce;
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
