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

    public void InitializeController()
    {
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMeteor(timeToRespawn));

    }

    public void UpdateController()
    {
        RemoveAllNullMeteorsFromList();

        for (int i = currentMissiles.Count - 1; i >= 0; i--)
        {
            currentMissiles[i].transform.Translate(Vector3.right * missileSpeed * Time.deltaTime);
        }
    }

    public void RespawnMeteors()
    {
        xPositionToRespawn = Random.Range(xMinPositionToRespawn, xMaxPositionToRespawn);
        zRotate = Random.Range(zMinRotate, zMaxRotate);

        EnemyMissile newMeteor = Instantiate(enemyMissile);
        newMeteor.transform.position = new Vector3(xPositionToRespawn, 9f, 0);
        newMeteor.transform.Rotate(0, 0, zRotate);
        currentMissiles.Add(newMeteor);
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMeteor(timeToRespawn));
    }
    private IEnumerator RespawnNewMeteor(float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnMeteors();
    }

    public void RemoveAllNullMeteorsFromList()
    {
        if (currentMissiles.Count > 0)
        {
            currentMissiles.RemoveAll(Meteor => Meteor == null);
        }
    }
}
