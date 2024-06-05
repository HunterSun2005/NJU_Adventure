using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, ISaveable
{
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
    }

    public void RegisterSaveData()
    {
        DataManager.Instance.RegisterSaveData(this);
    }

    public void UnRegisterSaveData()
    {
        DataManager.Instance.UnRegisterSaveData(this);
    }

    private void OnEnable()
    {
        ISaveable saveable = this;
        saveable.RegisterSaveData();
    }

    private void OnDisable()
    {
        ISaveable saveable = this;
        saveable.UnRegisterSaveData();
    }

    private void OnDestroy()
    {
        UnRegisterSaveData();
    }
}
