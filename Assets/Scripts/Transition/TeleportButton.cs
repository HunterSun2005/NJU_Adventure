using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    public CharacterEventSO characterEventSO;
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO SceneToGo;
    public Vector3 positionToGo;
    public Character player;
    public Button BackButton;
    private bool isClicked = false;

    private void Awake()
    {
        BackButton.onClick.AddListener(TriggerAction);

        SceneLoader.Instance.OnSceneLoadComplete += OnSceneLoadComplete;
    }

    public void TriggerAction()
    {
        Debug.Log("传送");

        isClicked = true;

        loadEventSO.RaiseLoadRequestEvent(SceneToGo, positionToGo, true);

        characterEventSO.RaiseEvent(player);

        // player.OnStatusBarChanged?.Invoke(player);

        Debug.Log("传送结束");
    }

    private void OnSceneLoadComplete()
    {
        if (!isClicked)
        {
            return;
        }
        else
        {
            Debug.Log("TeleportButton.OnSceneLoadComplete: MainMap scene loaded.");
        if (DataManager.Instance != null)
        {
            Debug.Log("Game data load after MainMap scene was loaded.");
            DataManager.Instance.Load();

        }
        else
        {
            Debug.LogWarning("DataManager instance not found.");
        }

        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.OnSceneLoadComplete -= OnSceneLoadComplete; // 取消订阅，以避免内存泄漏
        }

        isClicked = false;
        }
    }
}
