using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromStart : MonoBehaviour
{
    // 按钮引用
    public Button loadGameButton;
    private bool isClicked = false;

    private void Start()
    {
        // 为按钮添加点击事件监听器
        loadGameButton.onClick.AddListener(OnLoadGameButtonClicked);
        
        // 订阅场景加载完成的回调
        SceneLoader.Instance.OnSceneLoadComplete += OnSceneLoadComplete;
    }

    private void OnLoadGameButtonClicked()
    {
        isClicked = true;
        // 异步加载主地图
        Debug.Log("LoadFromMenu.OnLoadGameButtonClicked: Loading MainMap scene.");
        
        // 假设你有一个方法来触发场景加载
        SceneLoader.Instance.OnLoadRequestEvent(SceneLoader.Instance.firstLoadScene, SceneLoader.Instance.firstPosition, true);
    }

    private void OnSceneLoadComplete()
    {
        if (!isClicked)
        {
            return;
        }
        else
        {
            Debug.Log("LoadFromStart.OnSceneLoadComplete: MainMap scene loaded.");
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

    private void OnDestroy()
    {
        // 取消订阅，以避免内存泄漏
        // if (SceneLoader.Instance != null)
        // {
        //     SceneLoader.Instance.OnSceneLoadComplete -= OnSceneLoadComplete;
        // }
    }
}
