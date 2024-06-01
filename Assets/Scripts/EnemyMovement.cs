using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private float speed = 5f;
    private int currentTargetIndex = 0;
    
    void Start()
    {
        currentTargetIndex = 0; // start target
    }

    void Update()
    {
        if (targets != null && targets.Length > 0)
        {
            Transform target = targets[currentTargetIndex];
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > 0.1f)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }

            if (distance <= 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
            }
        }
    }
}
