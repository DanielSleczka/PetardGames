using UnityEngine;

public class GameController : BaseController
{
    #region STATES
    private GameState gameState;

    #endregion

    #region CONTROLLERS

    [SerializeField] private MissileController missileController;
    [SerializeField] private EnemyMissileController enemyMissileController;

    #endregion

    #region VIEWS

    [SerializeField] private GameView gameView;
    [SerializeField] private LoadingView loadingView;

    #endregion

    protected override void InjectReferences()
    {
        gameState = new GameState(missileController, enemyMissileController, gameView);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(gameState);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }



}
