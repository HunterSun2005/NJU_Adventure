using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void loadfrommenu()
    {
        Debug.Log("Loading from menu.");
        if (DataManager.Instance != null)
            {
                DataManager.Instance.Load();
                Debug.Log("Load method called from other scene.");
            }
        else
            {
                Debug.LogWarning("DataManager instance not found.");
            }
    }
}
