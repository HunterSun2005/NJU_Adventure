using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour, IInteractable
{
    public CharacterEventSO characterEventSO;
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO SceneToGo;
    public Vector3 positionToGo;
    public Character player;

    public void TriggerAction()
    {
        Debug.Log("传送");

        player.ProcessValue += 0.25f;

        DataManager.Instance.Save();

        loadEventSO.RaiseLoadRequestEvent(SceneToGo, positionToGo, true);

        characterEventSO.RaiseEvent(player);

        // player.OnStatusBarChanged?.Invoke(player);

        Debug.Log("传送结束");
    }
}