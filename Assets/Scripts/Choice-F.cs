using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceGame : MonoBehaviour
{
    public GameObject Panel1; // Panel1��Ϸ����
    public GameObject Panel2; // Panel2��Ϸ����
    public GameObject Panel3;
    public static int  score;
    public Text scoreText;
   

    public void Jump()
    {
        Panel1.SetActive(false); // ����Panel1
        Panel2.SetActive(true); // ��ʾPanel2
        scoreText.text = "�÷�: " + score.ToString();
    }
    public void JumpLast()
    {
        Panel1.SetActive(false); // ����Panel1
        Panel2.SetActive(true); // ��ʾPanel2
        score += 0;
        scoreText.text = "��Ϸ���� �÷�: " + score.ToString();
    }
    public void Out()
    {
        Panel3.SetActive(false);
    }

  
}
