using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    public CinemachineFreeLook _cinemachineFreeLook;

    private float _startingXAxisSpeed;
    private float _startingYAxisSpeed;

    private void Start()
    {
        _startingXAxisSpeed = _cinemachineFreeLook.m_XAxis.m_MaxSpeed;
        _startingYAxisSpeed = _cinemachineFreeLook.m_YAxis.m_MaxSpeed;
    }

    private void FixedUpdate()
    {
        HandleMouseInputForCamera();
    }

    private void HandleMouseInputForCamera()
    {
        if (Input.GetMouseButton(1))
        {
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = _startingXAxisSpeed;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = _startingYAxisSpeed;
        }
        else
        {
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
