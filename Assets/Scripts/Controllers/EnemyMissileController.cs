using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileController : MonoBehaviour
{
    [Header("Enemy Missile")]
    [SerializeField] private float missileSpeed;
    [SerializeField] private EnemyMissile enemyMissile;
    [SerializeField] private List<EnemyMissile> currentMissiles;

    [Header("Respawn Position")]
    [SerializeField] private float xMinPositionToRespawn;
    [SerializeField] private float xMaxPositionToRespawn;
    private float xPositionToRespawn;

    [Header("Respawn Rotate")]
    [SerializeField] private float zMinRotate;
    [SerializeField] private float zMaxRotate;
    private float zRotate;

    [Header("Respawn Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float timeToRespawn;

    [SerializeField] private ScoreSystem scoreSystem;

    public void InitializeController()
    {
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMissile(timeToRespawn));

    }

    public void UpdateController()
    {
        RemoveAllNullMissilesFromList();

        // Moving all current missiles
        for (int i = currentMissiles.Count - 1; i >= 0; i--)
        {
            currentMissiles[i].transform.Translate(Vector3.right * missileSpeed * Time.deltaTime);
        }
    }

    public void RespawnMissiles()
    {
        // Randomize position and rotation
        xPositionToRespawn = Random.Range(xMinPositionToRespawn, xMaxPositionToRespawn);
        zRotate = Random.Range(zMinRotate, zMaxRotate);

        // Create and set new enemy missile
        EnemyMissile newEnemyMissile = Instantiate(enemyMissile);
        newEnemyMissile.transform.position = new Vector3(xPositionToRespawn, 9f, 0);
        newEnemyMissile.transform.Rotate(0, 0, zRotate);
        newEnemyMissile.OnMissileDestroyObject_AddListener(AddPoints);

        // Add to current missiles list
        currentMissiles.Add(newEnemyMissile);

        // Set new time to respawn
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMissile(timeToRespawn));
    }
    private IEnumerator RespawnNewMissile(float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnMissiles();
    }

    public void RemoveAllNullMissilesFromList()
    {
        if (currentMissiles.Count > 0)
        {
            currentMissiles.RemoveAll(EnemyMissile => EnemyMissile == null);
        }
    }

    public void AddPoints(float pointsValue)
    {
        scoreSystem.AddPoints(pointsValue);
    }
}
