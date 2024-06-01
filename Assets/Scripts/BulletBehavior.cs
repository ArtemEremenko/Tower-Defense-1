using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    
    public Vector2 direction;
    private float lifeTimer = 3;

    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Quaternion hitRotation = Quaternion.Euler(0,0, angle);
        Instantiate (hitEffect, transform.position, transform.rotation);

        EnemyHealth enemy = collision2D.gameObject.GetComponent<EnemyHealth>();
        
        if(enemy != null)
        {
            enemy.TakeDamage();
        }
        else
        {
            Debug.Log("no enemy found");
        }

        Destroy(gameObject);
    }
}
