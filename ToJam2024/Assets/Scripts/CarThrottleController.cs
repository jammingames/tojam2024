using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarThrottleController : MonoBehaviour, IPointerClickHandler
{
    public WheelGoZoom[] _wheelGoZooms;
    [SerializeField] private float carSpeed;
    [SerializeField] private Material activeMaterial;
    private MeshRenderer _meshRenderer;
    private Material _originalMaterial;

    private bool _isActive;
    
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        
        _originalMaterial = _meshRenderer.material;


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetAllThrottles();
        _isActive = !_isActive;

        if (_isActive)
        {
            _meshRenderer.material = activeMaterial;
        }
        else
        {
            _meshRenderer.material = _originalMaterial;
        }
    }


    private void SetAllThrottles()
    {
        foreach (var wheel in _wheelGoZooms)
        {
            Debug.Log("CHANGING A WHEEL");
            if (wheel.torqueSpeed != 0)
            {
                wheel.torqueSpeed = 0;
            }
            else
            {
                wheel.torqueSpeed = carSpeed;
            }
        }
    }
}
