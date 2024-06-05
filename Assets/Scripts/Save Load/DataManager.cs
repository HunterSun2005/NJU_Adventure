using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

[DefaultExecutionOrder(-100)]
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    [Header("事件监听")]
    public VoidEventSO saveDataEvent;

    private List<ISaveable> saveableList = new List<ISaveable>();

    private Data saveData;

    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "playerData.json");
        Debug.Log("File will be saved at: " + filePath);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        saveData = new Data();
    }

    private void OnEnable()
    {
        saveDataEvent.OnEventRaised += Save;
    }

    private void OnDisable()
    {
        saveDataEvent.OnEventRaised -= Save;
    }

    private void Update() 
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            Load();
        }
    }

    public void RegisterSaveData(ISaveable saveable)
    {
        if (!saveableList.Contains(saveable))
        {
            saveableList.Add(saveable);
        }
    }

    public void UnRegisterSaveData(ISaveable saveable)
    {
        saveableList.Remove(saveable);
    }

    public void Save()
    {
        foreach (var saveable in saveableList)
        {
            saveable.GetSaveData(saveData);
        }

        // 打印测试
        foreach(var item in saveData.characterPosList)
        {
            Debug.Log(item.key + "   " + item.value.ToVector3());
        }

        // 保存数据到磁盘
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePath, json);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            saveData = JsonUtility.FromJson<Data>(json);
        }
        else
        {
            Debug.LogWarning("No save data found");
            return;
        }

        foreach (var saveable in saveableList)
        {
            saveable.LoadSaveData(saveData);
        }
    }
}
