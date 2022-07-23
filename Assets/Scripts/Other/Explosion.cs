using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.75f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyMissile"))
        {
            Destroy(collision.gameObject);
        }
    }


}
