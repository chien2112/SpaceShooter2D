using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : Weapon
{
    [SerializeField] Transform shootingPoint2;
    [SerializeField] Transform shootingPoint3;
    [SerializeField] Transform shootingPoint4;
    [SerializeField] Transform shootingPoint5;
    [SerializeField] Transform shootingPoint6;

    public void Shoot(int index)
    {
        var go = projectile.GetObjectType(projectile);
        switch (index)
        {
            case 1:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint.position;
                break;
            case 2:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint2.position;
                break;
            case 3:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint3.position;
                break;
            case 4:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint4.position;
                break;
            case 5:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint5.position;
                break;
            case 6:
                go.gameObject.SetActive(true);
                go.transform.position = shootingPoint6.position;
                break;
        }


    }
}