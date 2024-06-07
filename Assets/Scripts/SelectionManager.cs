using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    Tower currentlySelectedTower = null;
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
        
        if (tower == null && currentlySelectedTower == null) 
        {
            return;
        }

        if (tower == null && currentlySelectedTower != null) 
        {
            DeselectTower();
            currentlySelectedTower = null;
        }
        
        if (tower && currentlySelectedTower == null)
        {
            SelectCurrentTower(tower);
        }

        if (tower && currentlySelectedTower != null)
        {
            DeselectTower();
            SelectCurrentTower(tower);
        }
    }

    private static Tower GetTower()
    {
        Debug.Log("TryGetTower");
        Vector2 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); //whre origin is a camera pos and direction is a mouse position

        if (hit)
        {
            Tower tower = hit.collider.GetComponent<Tower>();
            Debug.Log("tower");
            return tower;
            
        }
        Debug.Log("Nope");
        return null;
    }

    private void SelectCurrentTower(Tower tower)
    {
        Debug.Log("SelectTower");
        currentlySelectedTower = tower;

        currentlySelectedTower.rangeCircle.SetActive(true);
    }

    private void DeselectTower()
    {
        Debug.Log("DeselectTower");
        currentlySelectedTower.rangeCircle.SetActive(false);
    }
}
