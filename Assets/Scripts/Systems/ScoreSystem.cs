using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private EnemyMissileController enemyMissileController;

    [Header("Views")]
    [SerializeField] private GameView gameView;

    [Header("Points")]
    [SerializeField] private float gameSpeedBoostPoints;
    private float currentPoints;

    public void InitializeSystem()
    {
        currentPoints = 0f;
        AddPoints(currentPoints);
    }


    public void AddPoints(float pointsValue)
    {
        currentPoints += pointsValue;
        gameView.UpdatePoints(currentPoints);
    }

    public float GetCurrentPoints()
    {
        return currentPoints;
    }

    public void BoostGameSpeed()
    {
        // In this moment method is update in GameState
        if (currentPoints >= gameSpeedBoostPoints)
        {
            enemyMissileController.ChangeGameSpeed();
            gameSpeedBoostPoints += gameSpeedBoostPoints;
        }
    }
}
