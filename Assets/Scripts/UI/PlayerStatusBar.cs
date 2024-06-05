using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    [Header("广播")]
    public CharacterEventSO characterEventSO;

    [Header("组件")]
    public Image ProcessBar;

    public TMP_Text ProcessText;

    public TMP_Text Date;

    public void SetProcessBar(float value)
    {
        Debug.Log("PlayerStatusBar: SetProcessBar");
        ProcessBar.fillAmount = value;
    }
}
