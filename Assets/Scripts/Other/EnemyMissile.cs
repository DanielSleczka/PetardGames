using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] private Explosion explosion;
    [SerializeField] private float pointsValue;

    private UnityAction<float> onMissileDestroyObject;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Explosion"))
        {
            onMissileDestroyObject.Invoke(pointsValue);
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

    public void OnMissileDestroyObject_AddListener(UnityAction<float> callback)
    {
        onMissileDestroyObject += callback;
    }
}
