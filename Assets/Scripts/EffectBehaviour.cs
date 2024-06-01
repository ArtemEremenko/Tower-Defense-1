using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBehaviour : MonoBehaviour
{
    private float lifeTimer = 0.1f;
    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
