using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float shootThreshold;
    [SerializeField] [Range(0f, 1f)] private float reloadProgress;
    private float lastTimeShoot;

    [Header("Missile")]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Missile missile;
    [SerializeField] private float missileSpeed;


    private bool isLoaded;
    private bool canReload;


    public void InitializeController()
    {
        isLoaded = false;
    }
    public void UpdateController()
    {
        CreatingMissile();
    }

    public void CreatingMissile()
    {
        if (!isLoaded)
        {
            CreateNewMissile();
            isLoaded = true;
        }

        if (canReload)
        {
            ReloadMissile();
        }
    }

    public void EnableReload()
    {
        lastTimeShoot = Time.time;
        canReload = true;
    }
    public void ReloadMissile()
    {
        reloadProgress = (Time.time - lastTimeShoot) / shootThreshold;

        if (reloadProgress >= 1f)
        {
            isLoaded = false;
            canReload = false;
        }
    }

    public void CreateNewMissile()
    {
        Missile newMissile = Instantiate(missile, startPosition);
        newMissile.SetMissileSpeed(missileSpeed);
        newMissile.OnMissileLaunch_AddListener(EnableReload);
    }
}
