using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform[] waypoints;
    private int currentTargetIndex = 0;
    
    void Start()
    {
        currentTargetIndex = 0; // start target
    }

    void Update()
    {
        if (waypoints != null && waypoints.Length > 0)
        {
            Transform target = waypoints[currentTargetIndex];
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > 0.1f)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }

            if (distance <= 0.1f)
            {
                currentTargetIndex = currentTargetIndex + 1;
                
                if (currentTargetIndex == waypoints.Length)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    public void Initialize(Transform waypointsParent)
    {
        waypoints = new Transform[waypointsParent.childCount];
        
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsParent.GetChild(i);
        }

        transform.position = waypoints[0].position;
    }
}
