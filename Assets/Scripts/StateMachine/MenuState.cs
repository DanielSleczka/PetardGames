using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    private MenuView menuView;
    private LoadingSystem loadingSystem;
    private LoadingView loadingView;

    public MenuState(MenuView menuView, LoadingSystem loadingSystem, LoadingView loadingView)
    {
        this.menuView = menuView;
        this.loadingSystem = loadingSystem;
        this.loadingView = loadingView;
    }

    public override void InitializeState()
    {
        base.InitializeState();
        menuView.InitializeView();

        menuView.OnStartButtonClicked_AddListener(StartGame);
        menuView.OnExitButtonClicked_AddListener(Application.Quit);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void DestroyState()
    {
        base.DestroyState();
    }

    public void StartGame()
    {
        loadingView.ShowView();
        loadingSystem.StartLoadingScene(1);
    }
}
