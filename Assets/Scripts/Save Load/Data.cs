using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class KeyValuePairStringVector3
{
    public string key;
    public SerializableVector3 value;

    public KeyValuePairStringVector3(string key, Vector3 value)
    {
        this.key = key;
        this.value = new SerializableVector3(value);
    }
}

[System.Serializable]
public class KeyValuePairStringFloat
{
    public string key;
    public float value;

    public KeyValuePairStringFloat(string key, float value)
    {
        this.key = key;
        this.value = value;
    }
}

[System.Serializable]
public class KeyValuePairStringInt
{
    public string key;
    public int value;

    public KeyValuePairStringInt(string key, int value)
    {
        this.key = key;
        this.value = value;
    }
}


[System.Serializable]
public class Data
{
    
    public List<KeyValuePairStringVector3> characterPosList = new List<KeyValuePairStringVector3>();
    public List<KeyValuePairStringFloat> floatSavedDataList = new List<KeyValuePairStringFloat>();
    public List<KeyValuePairStringInt> intSavedDataList = new List<KeyValuePairStringInt>();

    // 将 Dictionary 转换为 List
    public void FromDictionary(Dictionary<string, Vector3> characterPosDict, Dictionary<string, float> floatSavedData, Dictionary<string, int> intSavedData)
    {
        characterPosList = new List<KeyValuePairStringVector3>();
        foreach (var kvp in characterPosDict)
        {
            characterPosList.Add(new KeyValuePairStringVector3(kvp.Key, kvp.Value));
        }

        floatSavedDataList = new List<KeyValuePairStringFloat>();
        foreach (var kvp in floatSavedData)
        {
            floatSavedDataList.Add(new KeyValuePairStringFloat(kvp.Key, kvp.Value));
        }

        intSavedDataList = new List<KeyValuePairStringInt>();
        foreach (var kvp in intSavedData)
        {
            intSavedDataList.Add(new KeyValuePairStringInt(kvp.Key, kvp.Value));
        }
    }

    // 将 List 转换为 Dictionary
    public void ToDictionary(out Dictionary<string, Vector3> characterPosDict, out Dictionary<string, float> floatSavedData, out Dictionary<string, int> intSavedData)
    {
        characterPosDict = new Dictionary<string, Vector3>();
        foreach (var kvp in characterPosList)
        {
            characterPosDict[kvp.key] = kvp.value.ToVector3();
        }

        floatSavedData = new Dictionary<string, float>();
        foreach (var kvp in floatSavedDataList)
        {
            floatSavedData[kvp.key] = kvp.value;
        }

        intSavedData = new Dictionary<string, int>();
        foreach (var kvp in intSavedDataList)
        {
            intSavedData[kvp.key] = kvp.value;
        }
    }
}
