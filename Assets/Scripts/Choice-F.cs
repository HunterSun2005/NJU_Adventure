using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceGame : MonoBehaviour
{
    public GameObject Panel1; // Panel1游戏对象
    public GameObject Panel2; // Panel2游戏对象
    public GameObject Panel3;
    public static int  score;
    public Text scoreText;
   

    public void Jump()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        scoreText.text = "得分: " + score.ToString();
    }
    public void JumpLast()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        score += 0;
        scoreText.text = "游戏结束 得分: " + score.ToString();
    }
    public void Out()
    {
        Panel3.SetActive(false);
    }

  
}
