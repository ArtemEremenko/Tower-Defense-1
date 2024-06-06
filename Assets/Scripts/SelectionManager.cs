using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    Tower currentlySelectedTower = null;
    Tower previouslySelectedTower = null;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTower();
        }
    }
    private void SelectTower()

    {
        Debug.Log("Trying to Select some...");

        Vector2 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); //whre origin is a camera pos and direction is a mouse position
        
        if (hit && hit.collider.GetComponent<Tower>())
        {
            Tower tower = hit.collider.GetComponent<Tower>();
            currentlySelectedTower = tower;
            
            currentlySelectedTower.GetComponent<Tower>().rangeCircle.SetActive(true);
            previouslySelectedTower = currentlySelectedTower;
            currentlySelectedTower = null;
        }
        
        else if (previouslySelectedTower != null)
        {
            previouslySelectedTower.GetComponent<Tower>().rangeCircle.SetActive(false);
        }
    }
}
