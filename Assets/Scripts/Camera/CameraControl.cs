using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraControl : MonoBehaviour
{
    [Header("事件监听")]
    public VoidEventSO afterSceneLoadedEvent;
    private  CinemachineConfiner confiner;

    private void Awake()
    {
        confiner = GetComponent<CinemachineConfiner>();
    }

    private void OnEnable()
    {
        afterSceneLoadedEvent.OnEventRaised += OnAfterSceneLoaderEvent;
    }
    private void OnDisable()
    {
        afterSceneLoadedEvent.OnEventRaised -= OnAfterSceneLoaderEvent;
    }

    private void OnAfterSceneLoaderEvent()
    {
        GetNewCameraBounds();
    }

    // private void Start()
    // {
    //     GetNewCameraBounds();
    // }
    private void GetNewCameraBounds()
    {
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (obj == null)
        {
            return;
        }
        else
        {
            confiner.m_BoundingShape2D = obj.GetComponent<Collider2D>();

            confiner.InvalidatePathCache();
        }
    }
}
