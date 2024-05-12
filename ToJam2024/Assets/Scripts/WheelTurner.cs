using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WheelTurner : MonoBehaviour, IPointerDownHandler
{
    private bool _isDragging; 
    
    private Vector2 startPosition;
    private float rotationSpeed = 5f;
    private HingeJoint _hingeJoint;
    private JointSpring _spring;
    private WheelGoZoom _wheelGoZoom;
    private MeshRenderer _meshRenderer;
    private Material _originalMaterial;

    [SerializeField] private bool isUsingDragThrottle;
    [SerializeField] private float rotationMax;
    [SerializeField] private float rotationMin;
    
    
    [SerializeField] private Material activeMaterial;
    [SerializeField] private float rotateInputMultiplier;
    [SerializeField] private float velocityInputMultiplier;
    [SerializeField] private float maxSpeed;

    [SerializeField] private Slider _horizontalSlider;
    [SerializeField] private Slider _verticalSlider;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _spring = _hingeJoint.spring;
        _wheelGoZoom = GetComponentInChildren<WheelGoZoom>();
        
        _meshRenderer = GetComponentInChildren<MeshRenderer>();

        _originalMaterial = _meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragging)
        {
            // // Calculate the current mouse position in the world space
            // Vector3 currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            Vector2 currentPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 
            //
            // // Calculate the rotation amount based on the difference between the start position and current position
            // Vector3 rotationAmount = (currentPosition - startPosition);
            //
            // // Rotate the object around its local y-axis based on mouse movement
            // transform.Rotate(Vector3.up, -rotationAmount.x * rotationSpeed, Space.World);
            //
            // // Update the start position for the next frame
            // startPosition = currentPosition;

            //
            float targetPosition =  Mathf.Clamp((startPosition.x - currentPosition.x) * rotateInputMultiplier, rotationMin, rotationMax);
            _spring.targetPosition = targetPosition;
            _hingeJoint.spring = _spring;
            _horizontalSlider.value = targetPosition;

            if (isUsingDragThrottle)
            {
                float targetVelocity = startPosition.y - currentPosition.y;
                // _wheelGoZoom.torqueSpeed = targetVelocity * velocityInputMultiplier;
                _verticalSlider.value = targetVelocity;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                _meshRenderer.material = _originalMaterial;

            }
        }
        if (!isUsingDragThrottle)
        {
            ///InputAxis throttle
            // _wheelGoZoom.torqueSpeed = maxSpeed * (Input.GetAxis("Vertical"));
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        /// Start dragging
        _meshRenderer.material = activeMaterial;

        _isDragging = true;
        // startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}
