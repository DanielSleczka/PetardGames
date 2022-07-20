using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    private LoadingSystem loadingSystem;
    private MenuView menuView;
    private LoadingView loadingView;

    public MenuState(LoadingSystem loadingSystem, MenuView menuView, LoadingView loadingView)
    {
        this.loadingSystem = loadingSystem;
        this.menuView = menuView;
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
