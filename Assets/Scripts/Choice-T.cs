using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceGameT : MonoBehaviour
{
    public GameObject Panel1; // Panel1游戏对象
    public GameObject Panel2; // Panel2游戏对象
    public GameObject Panel3;
    public static int  score;
    public Text scoreText;
    

    // Update is called once per frame
    
    public void Jump0()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        score++;
        scoreText.text = "得分: " + score.ToString();
    }
    public void JumpF()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        scoreText.text = "得分: " + score.ToString();
    }
    public void JumpLast0()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        score++;
        scoreText.text = "游戏结束 得分: " + score.ToString();
        score = 0;
    }
    public void JumpLastF()
    {
        Panel1.SetActive(false); // 隐藏Panel1
        Panel2.SetActive(true); // 显示Panel2
        scoreText.text = "游戏结束 得分: " + score.ToString();
        score = 0;
    }
    public void Out0()
    {
        Panel3.SetActive(false);
    }
    


    private void UpdateScoreText()
    {
       
        scoreText.text = "得分: " + score.ToString();
    }


}

