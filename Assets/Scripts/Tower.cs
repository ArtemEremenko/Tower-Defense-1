using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    [SerializeField] private float countdownToFire = 0f;
    [SerializeField] private float rateOfFire = 4f;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private GameObject shootBulletPrefab;
    [SerializeField] private Transform firePointEmitter;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float detectionRadius = 8f;
    [SerializeField] private LayerMask enemyLayerMask; 
    Transform currentTarget = null;

    void Update()
    {
        SelectTarget();
        AimTarget();
        
        Shoot();

        countdownToFire += Time.deltaTime;
    }

    private void SelectTarget()
    {
        if (currentTarget == null)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayerMask);
            
            if (targets.Length > 0)
            {
                currentTarget = targets[0].transform;
    
                if(IsTargetInRange())
                {
                    return;
                }
            }
            
        }
    }

    private bool IsTargetInRange()
    {
        if (currentTarget != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
            
            if (distanceToTarget > detectionRadius)
            {
                currentTarget = null;
            }
            else
            {
                return true;
            }
        }
        return false;
        
    }

    private void AimTarget()
    {
        if (IsTargetInRange())
        {
            Vector2 direction = (Vector2)(currentTarget.position - transform.position);

            float angleOfAim = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion onTargetRotation = Quaternion.Euler(0, 0, angleOfAim -90);
            
            float rotationSpeed = 500f;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, onTargetRotation, rotationSpeed * Time.deltaTime);
        }  
    }

    void Shoot()
    {
        if (currentTarget != null && countdownToFire >= 1 / rateOfFire)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, firePointEmitter.position, firePointEmitter.rotation);
            bullet.velocity = transform.up * bulletSpeed;

            GameObject shootEffect = Instantiate(shootBulletPrefab, firePointEmitter.position, firePointEmitter.rotation);
            shootEffect.transform.Rotate(0, 0, -90);
            
            Destroy(shootEffect, 0.05f);

            countdownToFire = 0;
        }
    }
}
