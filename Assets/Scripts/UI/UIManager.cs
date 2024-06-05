using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("事件监听")]
    public CharacterEventSO characterEventSO;
    public EventSystem eventSystem;

    [Header("组件")]

    public Button SettingsButton;

    public Button ReturnButton;
    public PlayerStatusBar playerStatusBar;

    public TMP_Text DateText;
    public TMP_Text ProcessText;
    public GameObject pausePanel;


    private void Awake()
    {
        SettingsButton.onClick.AddListener(TogglePausePanel);
        ReturnButton.onClick.AddListener(TogglePausePanel);
    }

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    private void OnEnable()
    {
        if (characterEventSO != null)
        {
            characterEventSO.OnEventRaised += OnPercentEvent;
        }
        else
        {
            Debug.LogWarning("UIManager: characterEventSO is null");
        }
    }

    private void OnDisable()
    {
        if (characterEventSO != null)
        {
            characterEventSO.OnEventRaised -= OnPercentEvent;
        }
        else
        {
            Debug.LogWarning("UIManager: characterEventSO is null");
        }
    }


    public void TogglePausePanel()
    {
        // Debug.Log(pausePanel.activeInHierarchy);
        if (pausePanel.activeInHierarchy)
        {
            // Debug.Log("OnPausePanel");
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausePanel();
        }
    }

    private void OnPercentEvent(Character character)
    {
        if (character != null)
        {
            Debug.Log("UIManager: " + character.characterName + " ProcessBarValue: " + character.ProcessValue);
            if (character.ProcessValue > 0.999f)
            {
                character.ProcessValue = 0;
                character.Date++;
            }
            
            var percentage = character.ProcessValue;
            playerStatusBar.SetProcessBar(percentage);
            DateText.text = "Day " + character.Date.ToString();
            ProcessText.text = "Process:  " + percentage.ToString("P0", CultureInfo.InvariantCulture);
        }
        else
        {
            Debug.LogWarning("UIManager: character is null");
        }
    }
}
