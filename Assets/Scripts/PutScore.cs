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
        scoreText.text = "�÷�: " + score.ToString();  // ������ʾ�÷ֵ�UI�ı�����
    }
}
