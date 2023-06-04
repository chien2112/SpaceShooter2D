using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannon : Weapon
{
    [SerializeField] Transform shootingPoint2;

    public void Shoot(int index)
    {
        var go = projectile.GetObjectType(projectile);

        if(index == 1)
        {
            go.gameObject.SetActive(true);
            go.transform.position = shootingPoint.position;
        }
        else
        {
            go.gameObject.SetActive(true);
            go.transform.position = shootingPoint2.position;
        }
        
    }
}
