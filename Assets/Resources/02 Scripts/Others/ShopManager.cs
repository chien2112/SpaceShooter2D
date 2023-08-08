using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private List<Transform> pages = new List<Transform>();
    [SerializeField] private List<SOWeapon> soWeapons = new List<SOWeapon>();
    [SerializeField] private Transform upgradeBoard;
    private GameObject weaponShopTemplate;
    private TextMeshProUGUI txtCoin;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        txtCoin = FindGameObject.FindChildGameObjectByName(upgradeBoard, "txtCoin").GetComponent<TextMeshProUGUI>();
        UpdateCoinText();

        weaponShopTemplate = Resources.Load<GameObject>("01 Prefabs/Others/WeaponShopTemplate");

        pages.Clear();
        Transform pageArea = FindGameObject.FindChildGameObjectByName(upgradeBoard, "PageArea").transform;
        foreach (Transform page in pageArea)
        {
            pages.Add(page);
        }
        foreach (Transform p in pages)
        {
            if (p.gameObject.name == ShopPageName.PageWeapon.ToString())
            {
                Transform page = FindGameObject.FindChildGameObjectByName(upgradeBoard, ShopPageName.PageWeapon.ToString());
                Transform shopContent = FindGameObject.FindChildGameObjectByName(page, "ShopContent");
                foreach(Transform child in shopContent)
                {
                    Destroy(child.gameObject);
                }
                foreach (SOWeapon so in soWeapons)
                {
                    GameObject template = Instantiate(weaponShopTemplate, shopContent);
                    WeaponInShop weaponInShop = template.GetComponent<WeaponInShop>();
                    weaponInShop.soWeapon = so;
                }
            }
        }
    }
    public void UpdateCoinText()
    {
        txtCoin.text = SavingSystem.Instance.dataPlayer.coin.ToString();
    }


}
