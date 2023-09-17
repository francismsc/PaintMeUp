using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject gameplayPanel;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private TextMeshProUGUI timerValue;
    [SerializeField]
    private Image currentColorPanel;
    [SerializeField]
    private Image objectiveColorPanel;
    [SerializeField]
    private TextMeshProUGUI CorrectAnswersCounter;
    [SerializeField]
    private GameObject WinningPanel;
    public static event Action OnGameplayActive;


    private void OnEnable()
    {
        Timer.OnTimeUpdate += ChangeTimeUI;
        Controller.OnColorUpdate += ChangeCurrentColorUI;
        Controller.OnCorrectColor += ChangeCorrectAnswersCountUI;
        Controller.OnWin += WinningScreenUI;
        Controller.OnChangeRandomColor += ChangeRandomColorUI;

    }
    public void OpenPanel()
    {
        gameplayPanel.SetActive(true);
        Player.SetActive(true);
        OnGameplayActive?.Invoke();
        
    }

    public void ChangeTimeUI(int timeRemaining)
    {
        timerValue.text = timeRemaining.ToString(); 
    }

    public void ChangeCurrentColorUI(Color currentColor)
    {
        currentColorPanel.color = currentColor;
    }

    public void ChangeCorrectAnswersCountUI(int amount,int objectiveGoal)
    {
        CorrectAnswersCounter.text = amount.ToString()+"/"+objectiveGoal.ToString();
    }

    public void ChangeRandomColorUI(Color objectiveColor)
    {
        objectiveColorPanel.color = objectiveColor;
    }

    public void WinningScreenUI()
    {
        WinningPanel.SetActive(true);
    }
}
