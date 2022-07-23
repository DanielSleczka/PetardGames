using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missile : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform targetPoint;
    private Transform currentTarget;
    [SerializeField] private Transform explosion;
    private static Vector2 targetPosition;

    private float missileSpeed;

    private bool isShooting;
    private bool canShoot;

    #region Delegates

    private UnityAction onMissileLaunch;

    #endregion

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        Shooting();
        UpdateMissile();
    }
    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Transform newTargetPoint = Instantiate(targetPoint, targetPosition, targetPoint.rotation);
            currentTarget = newTargetPoint;
            onMissileLaunch?.Invoke();
            isShooting = true;
            canShoot = false;
        }
    }

    private void UpdateMissile()
    {
        if (!isShooting)
        {
            return;
        }

        if (isShooting)
        {
            // Moving missile
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * missileSpeed);

            // Count distance
            float distanceToTarget = Vector3.Distance(currentTarget.position, transform.position);
            if (distanceToTarget <= 0.02f)
            {
                DestroyCurrentObjects();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyMissile"))
        {
            DestroyCurrentObjects();
        }
    }

    public void DestroyCurrentObjects()
    {
        MissileExplosion();
        Destroy(currentTarget.gameObject);
        Destroy(gameObject);
    }

    public void MissileExplosion()
    {
        Transform newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
    }

    public void SetMissileSpeed(float missileSpeed)
    {
        this.missileSpeed = missileSpeed;
    }

    public void OnMissileLaunch_AddListener(UnityAction callback)
    {
        onMissileLaunch += callback;
    }
}
