using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarThrottleController : MonoBehaviour, IPointerClickHandler
{
    public WheelGoZoom[] _wheelGoZooms;
    public bool throttleOnStart = true;
    public bool allowClick = false;
    [SerializeField] private float carSpeed;
    [SerializeField] private Material activeMaterial;
    private MeshRenderer _meshRenderer;
    private Material _originalMaterial;

    private bool _isActive;
    
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        
        _originalMaterial = _meshRenderer.material;
        if (throttleOnStart) SetAllThrottles();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!allowClick) return;
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
            wheel.torqueSpeed = wheel.torqueSpeed == 0 ? carSpeed : 0; //only set if its zero
        }
    }
}
