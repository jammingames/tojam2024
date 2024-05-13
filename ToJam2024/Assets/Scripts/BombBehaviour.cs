using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombBehaviour : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Exploder explosionRadius;
    [SerializeField] private GameObject explosionPrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        Grabber grabber = other.gameObject.GetComponent<Grabber>();
        if (grabber != null)
        {
            grabber.Grab(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateDetonateCountdown();
        }
    }

    private void ActivateDetonateCountdown()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        StartCoroutine(CountdownThenExplode(3));
    }

    private IEnumerator CountdownThenExplode(float waitTime)
    {
        explosionRadius.gameObject.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(waitTime);
        Explode();
        
    }


    private void Explode()
    {
        Debug.Log("EXPLODING");
        explosionRadius.Explode();
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        // explosion.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        Destroy(gameObject);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ActivateDetonateCountdown();
    }
}
