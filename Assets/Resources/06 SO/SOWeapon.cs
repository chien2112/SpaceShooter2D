using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/Weapon")]
public class SOWeapon : ScriptableObject
{
    public string path;
    public string weaponName;
    public string bulletName;
    public float fireRate;
    public float damage;
    public float bulletSpeed;
    
}
