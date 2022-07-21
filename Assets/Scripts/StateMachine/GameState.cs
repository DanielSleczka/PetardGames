using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{

    #region CONTROLLERS & SYSTEMS

    private MissileController missileController;
    private EnemyMissileController enemyMissileController;

    #endregion

    #region VIEWS

    private GameView gameView;
    #endregion

    public GameState(MissileController missileController, EnemyMissileController enemyMissileController, GameView gameView)
    {
        this.missileController = missileController;
        this.enemyMissileController = enemyMissileController;
        this.gameView = gameView;
    }



    public override void InitializeState()
    {
        base.InitializeState();
        missileController.InitializeController();
        enemyMissileController.InitializeController();
    }


    public override void UpdateState()
    {
        base.UpdateState();
        missileController.UpdateController();
        enemyMissileController.UpdateController();

    }
    public override void DestroyState()
    {
        base.DestroyState();
    }
}
