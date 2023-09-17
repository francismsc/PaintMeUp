using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfacePanels : MonoBehaviour, IUserInterface
{
    [SerializeField]
    private UIPreStart _preStart;
    [SerializeField]
    private UIGameplay _gameplay;
    //[SerializeField]
    //private UIVictory _victory;
    //[SerializeField]
    //private UIDefeat _defeat;

    public void ChangeUIState(UIStates p_uiState)
    {
        switch(p_uiState)
        {
            case UIStates.PRE_START:
                _preStart.OpenPanel();
                break;
            case UIStates.GAMEPLAY:
                _preStart.ClosePanel();
                _gameplay.OpenPanel();
                break;
            case UIStates.VICTORY:
                break;
            case UIStates.DEFEAT:
                break;
        }
    }

}
