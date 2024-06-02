using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab;
    private int damage = 12;
    private float bulletLifeTime = 3;

    void Update()
    {
        bulletLifeTime -= Time.deltaTime;

        if (bulletLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject hitEffect = Instantiate (hitEffectPrefab, transform.position, transform.rotation);
        Destroy(hitEffect, 0.1f);

        HealthSystem enemy = collision2D.gameObject.GetComponent<HealthSystem>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
