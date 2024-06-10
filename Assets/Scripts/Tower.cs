using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tower : MonoBehaviour
{
    [SerializeField] private float countdownToFire = 0f;
    [SerializeField] private float rateOfFire = 4f;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private GameObject shootBulletPrefab;
    [SerializeField] private Transform firePointEmitter;
    [SerializeField] public GameObject rangeCircle;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] public float detectionRadius = 8f;
    [SerializeField] private LayerMask enemyLayerMask; 
    Transform currentTarget = null;
    bool isAimed = false;

    //Tower tower = SelectionManager.currentlySelectedTower;
    void Start()
    {
        rangeCircle.transform.localScale = Vector3.one * detectionRadius;
    }

    void Update()
    {
        // upgrades
        if (Input.GetKeyUp(KeyCode.R) && SelectionManager.currentlySelectedTower == this)
        {
            UpgradeRange();
            Debug.Log("R for Range in " + this.name);
        }

        countdownToFire += Time.deltaTime;

        if (currentTarget != null && !IsTargetInRange())
        {
            currentTarget = null;
        }
        if (currentTarget == null)
        {
            SelectTarget();
        }
        if (currentTarget == null)
        {
            return;
        }
        AimTarget();

        if (isAimed)
        {
            Shoot();
        }
    }

    private void SelectTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayerMask);
        
        if (targets.Length > 0)
        {
            currentTarget = targets[0].transform;
        }
    }

    private bool IsTargetInRange()
    {
        float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
        bool isTargetInRange = distanceToTarget < detectionRadius;
        
        return isTargetInRange;
    }

    private void AimTarget()
    {
        Vector2 direction = (Vector2)(currentTarget.position - transform.position);
        
        Quaternion onTargetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        
        float rotationSpeed = 500f;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, onTargetRotation, rotationSpeed * Time.deltaTime);
        
        isAimed = transform.rotation == onTargetRotation;
    }

    void Shoot()
    {
        if (countdownToFire >= 1 / rateOfFire)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, firePointEmitter.position, firePointEmitter.rotation);
            bullet.velocity = transform.up * bulletSpeed;

            GameObject shootEffect = Instantiate(shootBulletPrefab, firePointEmitter.position, firePointEmitter.rotation);
            shootEffect.transform.Rotate(0, 0, -90);
            
            Destroy(shootEffect, 0.05f);

            countdownToFire = 0;
        }
    }

    private void OnDrawGizmosSelected ()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, detectionRadius);
    }

    public void UpgradeRange()
    {
        if (detectionRadius >= 12) return;
            
        detectionRadius = detectionRadius + 2;
        rangeCircle.transform.localScale = Vector3.one * detectionRadius;
    }

    // private void RangeCircleScale()
    // {
    //     //Tower tower = new Tower();
    //     Debug.Log("RangeCircleScale()");
        
    //     if (detectionRadius >= 12) return; 
            
    //     detectionRadius = detectionRadius + 2;
    //     rangeCircle.transform.localScale = rangeCircle.transform.localScale * detectionRadius;
    // }

}
