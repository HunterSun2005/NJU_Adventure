using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SceneLoadEventSO", menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

/// <summary>
/// 场景加载请求
/// </summary>
/// <param name="locationToLoad">要加载的场景</param>
/// <param name="positionToGo">Player目的坐标</param>
/// <param name="fadeScreen">是否渐入渐出</param>
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 positionToGo, bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, positionToGo, fadeScreen);
    }
}
