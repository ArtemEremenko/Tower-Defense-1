using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodSpritePrefab;
    
    public void TakeDamage()
    {
        Debug.Log("TakeDamage!");

        GameObject bloodSprite = Instantiate(bloodSpritePrefab, transform.position, transform.rotation);
        Destroy(bloodSprite, 60f);
    }
}
