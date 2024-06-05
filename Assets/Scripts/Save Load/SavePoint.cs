using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SavePoint : MonoBehaviour, IInteractable
{
    [Header("广播")]

    public VoidEventSO SaveGameEvent;

    // [Header("变量参数")]

    public Button saveButton;

    private void Start()
    {
        saveButton.onClick.AddListener(onClick);
    }
    
    public void TriggerAction() 
    {
        Debug.Log("存档");
        SaveGameEvent.RaiseEvent();
    }

    public void onClick()
    {
        Debug.Log("存档");
        SaveGameEvent.RaiseEvent(); //保存数据
    }
}
