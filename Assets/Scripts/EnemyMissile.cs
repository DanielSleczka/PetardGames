using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] private Explosion explosion;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Explosion();
        }

        if (collision.CompareTag("MissileCommand"))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        Destroy(gameObject);
        Explosion newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
    }
}
