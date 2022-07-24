using System.Collections;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private EnemyMissileController enemyMissileController;

    [Header("Views")]
    [SerializeField] private GameView gameView;
    [SerializeField] private LoseView loseView;

    [Header("Points")]
    [SerializeField] private float gameSpeedBoostPoints;
    private float newPointThreshold;
    private float currentPoints;

    public void InitializeSystem()
    {
        currentPoints = 0f;
        AddPoints(currentPoints);
        newPointThreshold = gameSpeedBoostPoints;
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

    public void CountPoints()
    {
        StartCoroutine(CountPointsWithDelay(0.00001f));
    }

    private IEnumerator CountPointsWithDelay(float delay)
    {
        for (float i = 0; i <= currentPoints; i++)
        {
            yield return new WaitForSeconds(delay);
            loseView.ShowScoreValue(i);
        }
        loseView.ChangeTextValueScale(Vector2.one * 1.5f);
    }

    public void BoostGameSpeed()
    {
        // In this moment method is update in GameState
        if (currentPoints >= newPointThreshold)
        {
            enemyMissileController.ChangeGameSpeed();
            newPointThreshold += gameSpeedBoostPoints;
        }
    }
}
