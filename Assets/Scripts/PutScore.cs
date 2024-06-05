using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PutScore : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public void IncreaseScore()
    {
        scoreText.text = "得分: " + score.ToString();  // 更新显示得分的UI文本内容
    }
}
