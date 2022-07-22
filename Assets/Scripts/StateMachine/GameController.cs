using UnityEngine;

public class GameController : BaseController
{
    #region STATES
    private GameState gameState;

    #endregion

    #region CONTROLLERS & SYSTEMS

    [SerializeField] private MissileController missileController;
    [SerializeField] private EnemyMissileController enemyMissileController;
    [SerializeField] private ScoreSystem scoreSystem;
    #endregion

    #region VIEWS

    [SerializeField] private GameView gameView;
    [SerializeField] private LoadingView loadingView;

    #endregion

    protected override void InjectReferences()
    {
        gameState = new GameState(missileController, enemyMissileController, scoreSystem, gameView);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(gameState);
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
