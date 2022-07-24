using UnityEngine;

public class MenuController : BaseController
{
    #region STATES

    private MenuState menuState;

    #endregion

    #region SYSTEMS

    [SerializeField] private LoadingSystem loadingSystem;

    #endregion

    #region VIEWS

    [SerializeField] private MenuView menuView;
    [SerializeField] private LoadingView loadingView;

    #endregion

    protected override void InjectReferences()
    {
        menuState = new MenuState(loadingSystem, menuView, loadingView);
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
