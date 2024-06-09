using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUpgrade : Upgrade
{
    public override void ApplyUpgrade(Tower tower)
    {
        if (tower.detectionRadius >= 12) return;
            
        tower.detectionRadius = tower.detectionRadius + 2;
        tower.rangeCircle.transform.localScale = tower.rangeCircle.transform.localScale.normalized;
        tower.rangeCircle.transform.localScale = tower.rangeCircle.transform.localScale * tower.detectionRadius;
        //new Vector3(tower.detectionRadius, tower.detectionRadius, tower.detectionRadius);
         //RangeCircleScale();
    }

    // private void RangeCircleScale()
    // {
    //     Tower tower = new Tower();
        
    //     tower.rangeCircle.transform.localScale = tower.rangeCircle.transform.localScale * tower.detectionRadius;
    // }
}
