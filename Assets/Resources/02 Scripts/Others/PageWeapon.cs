using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageWeapon : MonoBehaviour
{
    public List<SOWeapon> soWeapons = new List<SOWeapon>();
    public Transform shopContent;
    public GameObject weaponShopTemplate;

    private void Awake()
    {
        foreach (SOWeapon so in soWeapons)
        {
            GameObject template = Instantiate(weaponShopTemplate, shopContent);
            WeaponInShop weaponInShop = template.GetComponent<WeaponInShop>();
            weaponInShop.soWeapon = so;
        }
    }
}
