using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private GameObject bloodSpritePrefab;
    private int health = 100;
    
    public void TakeDamage(int damage)
    {
        health = health - damage; 
        
        if (health <= 0)
        {
            Die();
        }

        GameObject bloodSprite = Instantiate(bloodSpritePrefab, transform.position, transform.rotation);
        Destroy(bloodSprite, 60f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
