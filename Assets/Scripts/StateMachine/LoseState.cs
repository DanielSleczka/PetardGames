using UnityEngine;

public class LoseState : BaseState
{
    private ScoreSystem scoreSystem;
    private LoadingSystem loadingSystem;
    private LoadingView loadingView;
    private LoseView loseView;

    public LoseState(ScoreSystem scoreSystem, LoadingSystem loadingSystem, LoadingView loadingView, LoseView loseView)
    {
        this.scoreSystem = scoreSystem;
        this.loadingSystem = loadingSystem;
        this.loadingView = loadingView;
        this.loseView = loseView;
    }

    public override void InitializeState()
    {
        base.InitializeState();
        loseView.ShowView();
        scoreSystem.CountPoints();

        loseView.OnRestartGameButtonClicked_AddListener(ResetLevel);
        loseView.OnExitButtonClicked_AddListener(Application.Quit);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }

    private void ResetLevel()
    {
        loadingView.ShowView();
        loadingSystem.StartLoadingScene(1);
    }
}
