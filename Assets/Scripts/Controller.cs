using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private IUserInterface _userInterface;
    private GameStates _currentState;
    private Color currentColor;
    [SerializeField] PaintInteraction paintInteraction;
    [SerializeField] GetCameraColor getCameraColor;
    [SerializeField] ColorChecker colorChecker;

    public static event Action OnTimerStart;
    public static event Action OnRightColor;

    public static event Action<Color> OnColorUpdate;
    public static event Action<int,int> OnCorrectColor;
    public static event Action OnWin;
    public static event Action OnLoss;
    public static event Action<Color> OnChangeRandomColor;
    private int correctAswersCounter = 0;
    [SerializeField] private int objectiveGoal = 6;
    public static event Action OnWrongColor;

    private void OnEnable()
    {
        UIPreStart.OnPanelRevealed += () => StartCoroutine(WaitForPreStartKey());      
    }

    private void OnDisable()
    {
        UIPreStart.OnPanelRevealed -= () => StopCoroutine(WaitForPreStartKey());
    }

    private void Start()
    {
        ChangeGameState(GameStates.PRE_START);
    }

    private void Awake()
    {
        _userInterface = FindObjectOfType<UserInterfacePanels>();
    }

    private void ChangeGameState(GameStates p_gameState)
    {
        _currentState = p_gameState;

        switch (_currentState)
        {
            case GameStates.PRE_START:
                _userInterface.ChangeUIState(UIStates.PRE_START);
                break;
            case GameStates.GAMEPLAY:
                _userInterface.ChangeUIState(UIStates.GAMEPLAY);
                OnTimerStart?.Invoke();
                OnCorrectColor?.Invoke(correctAswersCounter,objectiveGoal);
                GetRandomColor();

                break;
            case GameStates.VICTORY:
                _userInterface.ChangeUIState(UIStates.VICTORY);
                break;
            case GameStates.DEFEAT:
                _userInterface.ChangeUIState(UIStates.DEFEAT);
                break;
        }
    }

    private IEnumerator WaitForPreStartKey()
    {
        while (!Input.anyKey) yield return null;
        ChangeGameState(GameStates.GAMEPLAY);
    }

    private void ChangeCurrentColor(Color currentcolor)
    {
        currentColor = currentcolor;
        OnColorUpdate.Invoke(currentColor);
    }

    public void Paint()
    {
        if(paintInteraction.Paint(currentColor))
        {
            if (colorChecker.AreColorsAlmostEqual(currentColor))
            {
                OnCorrectColor.Invoke(++correctAswersCounter, objectiveGoal);
                Debug.Log("True");
                WinCondition();

            }
            else
            {
                Debug.Log("false");
                OnWrongColor?.Invoke();
            }
        }
    }

    public void GetRandomColor()
    {
        colorChecker.RandomColor();
        OnChangeRandomColor.Invoke(colorChecker.GetObjectiveColor());
    }

    public void GetCameraColor()
    {
        currentColor = getCameraColor.ChangeColor();
        OnColorUpdate.Invoke(currentColor);
    }

    public void WinCondition()
    {
        if(correctAswersCounter == objectiveGoal)
        {
            Debug.Log("You win");
            OnWin?.Invoke();
        }else
        {

        }
                
    }






}
