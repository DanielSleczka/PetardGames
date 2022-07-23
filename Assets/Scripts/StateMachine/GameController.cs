using UnityEngine;

public class GameController : BaseController
{
    #region STATES
    private GameState gameState;
    private LoseState loseState;

    #endregion

    #region CONTROLLERS & SYSTEMS

    [SerializeField] private MissileController missileController;
    [SerializeField] private EnemyMissileController enemyMissileController;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private LoadingSystem loadingSystem;
    #endregion

    #region VIEWS

    [SerializeField] private GameView gameView;
    [SerializeField] private LoadingView loadingView;
    [SerializeField] private LoseView loseView;

    #endregion

    protected override void InjectReferences()
    {
        gameState = new GameState(missileController, enemyMissileController, scoreSystem, gameView);
        loseState = new LoseState(scoreSystem, loadingSystem, loadingView, loseView);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(gameState);
        missileController.OnGameOver_AddListener(() => ChangeState(loseState));
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
