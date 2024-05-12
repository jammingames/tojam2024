using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketBooster : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody rb;
    [SerializeField] private float boosterSpeed = 100f;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private ParticleSystem particleSystem;
    private Material _originalMaterial;
    private MeshRenderer _meshRenderer;

    private bool _isActivated; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _originalMaterial = _meshRenderer.material;
    }

    private void Update()
    {
        if (_isActivated)
        {
            if (Input.GetMouseButtonUp(0))
            {
                ActivateThruster(false);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isActivated)
        {
            Boost();
        }
    }

    private void ActivateThruster(bool activate)
    {
        _isActivated = activate;
        if (activate)
        {
            particleSystem.Play();
            _meshRenderer.material = activeMaterial;
        }
        else
        {
            particleSystem.Stop();
            _meshRenderer.material = _originalMaterial;
        }
    }

    private void Boost()
    {
        rb.AddForce(transform.right * boosterSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        { 
            ActivateThruster(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer up");
    }
}
