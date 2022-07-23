using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuView : BaseView
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitButton;


    public void InitializeView()
    {
        base.ShowView();
    }

    public void OnStartButtonClicked_AddListener(UnityAction listener)
    {
        startGameButton.onClick.AddListener(listener);
    }

    public void OnStartButtonClicked_RemoveListener(UnityAction listener)
    {
        startGameButton.onClick.RemoveListener(listener);
    }

    public void OnExitButtonClicked_AddListener(UnityAction listener)
    {
        exitButton.onClick.AddListener(listener);
    }

    public void OnExitButtonClicked_RemoveListener(UnityAction listener)
    {
        exitButton.onClick.RemoveListener(listener);
    }
}
