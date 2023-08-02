using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/Weapon")]
public class SOWeapon : ScriptableObject
{
    public Sprite sprite;
    public GameObject weaponPrefab;
    public GameObject projectilePrefab;
    [Space(10)]
    public string weaponName;
    [Space(10)]
    public float fireRate;
    public float damage;
    public float bulletSpeed;
    public int maxLevel;
    public int upgradeCost;
    public int price;  

}
