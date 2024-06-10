using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static Tower currentlySelectedTower = null;
    //Tower previouslySelectedTower = null;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTower();
        }
    }

    private void SelectTower()
    {
        Tower tower = GetTower();
        
        if (tower == currentlySelectedTower) 
        {
            return;
        }

        if (tower == null)
        {
            DeselectTower();
            currentlySelectedTower = null;
            return;
        }
        
        if (currentlySelectedTower != null)
        {
            DeselectTower();
        }

        SelectCurrentTower(tower);
    }

    private static Tower GetTower()
    {
        Vector2 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); //whre origin is a camera pos and direction is a mouse position

        if (hit)
        {
            Tower tower = hit.collider.GetComponent<Tower>();
            return tower;
        }
        return null;
    }

    private void SelectCurrentTower(Tower tower)
    {
        currentlySelectedTower = tower;

        currentlySelectedTower.rangeCircle.SetActive(true);
    }

    private void DeselectTower()
    {
        currentlySelectedTower.rangeCircle.SetActive(false);
    }
}
