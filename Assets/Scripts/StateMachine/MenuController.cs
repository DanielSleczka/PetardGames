using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    private MenuState menuState;

    [SerializeField] private MenuView menuView;
    [SerializeField] private LoadingSystem loadingSystem;
    [SerializeField] private LoadingView loadingView;


    protected override void InjectReferences()
    {
        menuState = new MenuState(menuView, loadingSystem, loadingView);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(menuState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

    }
}
