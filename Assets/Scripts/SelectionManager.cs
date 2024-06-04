using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            SelectTower();
        }
    }
    private void SelectTower()
    {
        Debug.Log("Trying to Select some...");
    }
}
