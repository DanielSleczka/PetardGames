using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [Header("Views")]
    [SerializeField] private GameView gameView;

    [Header("Points")]
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
}
