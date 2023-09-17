using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPreStart : MonoBehaviour
{
    [SerializeField]
    private GameObject preStartPanel;

    public static event Action OnPanelRevealed;
    public void OpenPanel()
    {
        preStartPanel.SetActive(true);
        OnPanelRevealed?.Invoke();
    }

    public void ClosePanel()
    {
        Debug.Log("Cmon");
        preStartPanel.SetActive(false);
    }
}
