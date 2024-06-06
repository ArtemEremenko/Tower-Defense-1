using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab;
    private int damage = 10;
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
        // rotation hitEffect to normal of hit
        Vector3 normal = collision2D.contacts[0].normal;
        
        Quaternion hitRotation = Quaternion.LookRotation(Vector3.forward, normal);
        hitRotation = Quaternion.Euler(0, 0, hitRotation.eulerAngles.z + 90);

        GameObject hitEffect = Instantiate (hitEffectPrefab, transform.position, hitRotation);
        
        Destroy(hitEffect, 0.2f);

        HealthSystem enemy = collision2D.gameObject.GetComponent<HealthSystem>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
