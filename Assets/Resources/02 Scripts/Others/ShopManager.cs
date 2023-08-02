using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<SOWeapon> weapons = new List<SOWeapon>();
    public GameObject weaponShopTemplate;
    public Transform shopContent;

    private void Awake()
    {
        foreach (SOWeapon weapon in weapons)
        {
            GameObject item = Instantiate(weaponShopTemplate, shopContent);
            item.transform.Find("Image").GetComponent<Image>().sprite = weapon.sprite;
            item.transform.Find("txtName").GetComponent<TextMeshProUGUI>().text = weapon.name;
            item.transform.Find("txtCost").GetComponent<TextMeshProUGUI>().text = weapon.upgradeCost.ToString();
            //item.transform.Find("txtLevel").GetComponent<TextMeshProUGUI>().text = weapon.upgradeCost.ToString();
        }
    }
}
