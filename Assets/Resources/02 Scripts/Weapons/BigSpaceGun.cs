using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpaceGun : Weapon
{
    public void Shoot(int index)
    {
        var go = projectile.GetObjectType(projectile);
        go.gameObject.SetActive(true);
        go.transform.position = shootingPoint.position;
    }
}