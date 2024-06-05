using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, ISaveable
{
    [Header("基本属性")]
    public string characterName;
    public float ProcessValue;
    public int Date;
    public UnityEvent<Character> OnStatusBarChanged;

    private void NewGame()
    {
        ProcessValue = 0.5f;
        Date = 1;
        //TODO: 重置位置
    }

    private void Start()
    {
        OnStatusBarChanged?.Invoke(this);
    }
    
    private void OnEnable()
    {
        ISaveable saveable = this;
        saveable.RegisterSaveData();
        // newgameevent.OnEventRaised += NewGame;
    }

    private void OnDisable()
    {
        ISaveable saveable = this;
        saveable.UnRegisterSaveData();
        // newgameevent.OnEventRaised -= NewGame;
    }

    public DataDefination GetDataID()
    {
        return GetComponent<DataDefination>();
    }

    public void GetSaveData(Data data)
    {
        string id = GetDataID().ID;
        SerializableVector3 position = new SerializableVector3(transform.position);

        bool positionExists = false;
        for (int i = 0; i < data.characterPosList.Count; i++)
        {
            if (data.characterPosList[i].key == id)
            {
                data.characterPosList[i].value = position;
                positionExists = true;
                break;
            }
        }
        if (!positionExists)
        {
            data.characterPosList.Add(new KeyValuePairStringVector3(id, transform.position));
        }

        bool processValueExists = false;
        for (int i = 0; i < data.floatSavedDataList.Count; i++)
        {
            if (data.floatSavedDataList[i].key == id + "ProcessValue")
            {
                data.floatSavedDataList[i].value = this.ProcessValue;
                processValueExists = true;
                break;
            }
        }
        if (!processValueExists)
        {
            data.floatSavedDataList.Add(new KeyValuePairStringFloat(id + "ProcessValue", this.ProcessValue));
        }

        bool dateExists = false;
        for (int i = 0; i < data.intSavedDataList.Count; i++)
        {
            if (data.intSavedDataList[i].key == id + "Date")
            {
                data.intSavedDataList[i].value = this.Date;
                dateExists = true;
                break;
            }
        }
        if (!dateExists)
        {
            data.intSavedDataList.Add(new KeyValuePairStringInt(id + "Date", this.Date));
        }
    }

    public void LoadSaveData(Data data)
    {
        string id = GetDataID().ID;

        foreach (var kvp in data.characterPosList)
        {
            if (kvp.key == id)
            {
                transform.position = kvp.value.ToVector3();
                break;
            }
        }

        foreach (var kvp in data.floatSavedDataList)
        {
            if (kvp.key == id + "ProcessValue")
            {
                this.ProcessValue = kvp.value;
                break;
            }
        }

        foreach (var kvp in data.intSavedDataList)
        {
            if (kvp.key == id + "Date")
            {
                this.Date = kvp.value;
                break;
            }
        }

        OnStatusBarChanged?.Invoke(this);
    }
}
