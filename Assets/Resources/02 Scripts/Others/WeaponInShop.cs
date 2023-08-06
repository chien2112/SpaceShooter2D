using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class WeaponInShop : MonoBehaviour
{
    [SerializeField] private Button btnEquip;
    [SerializeField] private Button btnUnequip;
    [SerializeField] private Button btnBuy;
    [SerializeField] private Button btnUpgrade;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtPrice;
    [SerializeField] private TextMeshProUGUI txtCost;
    [SerializeField] private TextMeshProUGUI txtLevel;

    [SerializeField] public DataWeapon dataWeapon;
    [SerializeField] public SOWeapon soWeapon;

    [SerializeField] private Player player;
    [SerializeField] private SavingSystem savingSystem;
    private void Start()
    {
        Init();
    }
    void Init()
    {
        image = transform.Find("Image").GetComponent<Image>();
        txtName = transform.Find("txtName").GetComponent<TextMeshProUGUI>();
        txtPrice = transform.Find("txtPrice").GetComponent<TextMeshProUGUI>();
        txtCost = transform.Find("txtCost").GetComponent<TextMeshProUGUI>();
        txtLevel = transform.Find("txtLevel").GetComponent<TextMeshProUGUI>();

        btnEquip = transform.Find("btnEquip").GetComponent<Button>();
        btnUnequip = transform.Find("btnUnequip").GetComponent<Button>();
        btnBuy = transform.Find("btnBuy").GetComponent<Button>();
        btnUpgrade = transform.Find("btnUpgrade").GetComponent<Button>();

        btnEquip.onClick.RemoveAllListeners();
        btnUnequip.onClick.RemoveAllListeners();
        btnBuy.onClick.RemoveAllListeners();
        btnUpgrade.onClick.RemoveAllListeners();

        btnEquip.onClick.AddListener(ClickButtonEquip);
        btnUnequip.onClick.AddListener(ClickButtonUnequip);
        btnBuy.onClick.AddListener(ClickButtonBuy);
        btnUpgrade.onClick.AddListener(ClickButtonUpgrade);

        savingSystem = SavingSystem.Instance;
        dataWeapon = savingSystem.dataPlayer.dataWeapons.Where(x => x.name == soWeapon.weaponName).First();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        gameObject.name = soWeapon.weaponName;
        image.sprite = soWeapon.sprite;
        txtName.text = soWeapon.weaponName;
        txtPrice.text = "Price: " + soWeapon.price;
        txtLevel.text = "Level: " + dataWeapon.currentLevel;

        if (dataWeapon.isUnlocked)
        {
            txtCost.gameObject.SetActive(true);
            txtLevel.gameObject.SetActive(true);
            btnUpgrade.gameObject.SetActive(true);
            if (dataWeapon.isEquipped)
            {
                btnUnequip.gameObject.SetActive(true);
            }
            else
            {
                btnEquip.gameObject.SetActive(true);
            }
            if (dataWeapon.currentLevel == dataWeapon.soWeapon.maxLevel)
            {
                txtCost.gameObject.SetActive(false);
                btnUpgrade.gameObject.SetActive(false);
                txtLevel.text = "Level: " + dataWeapon.currentLevel.ToString() + " (MAX)";
            }
            else
            {
                txtCost.text = "Cost: " + dataWeapon.soWeapon.upgradeCosts[dataWeapon.currentLevel - 1];
            }
        }
        else
        {
            btnBuy.gameObject.SetActive(true);
            txtPrice.gameObject.SetActive(true);
        }

    }
    void ClickButtonEquip()
    {
        savingSystem.EquipWeapon(soWeapon.weaponName);
        btnEquip.gameObject.SetActive(false);
        btnUnequip.gameObject.SetActive(true);
    }
    void ClickButtonUnequip()
    {
        savingSystem.UnequipWeapon(soWeapon.weaponName);
        btnEquip.gameObject.SetActive(true);
        btnUnequip.gameObject.SetActive(false);
    }
    void ClickButtonBuy()
    {
        if(savingSystem.BuyWeapon(soWeapon.weaponName, soWeapon.price))
        {
            btnEquip.gameObject.SetActive(true);
            btnUnequip.gameObject.SetActive(false);
            btnBuy.gameObject.SetActive(false);
            btnUpgrade.gameObject.SetActive(true);
            txtPrice.gameObject.SetActive(false);
            txtLevel.gameObject.SetActive(true);
            txtCost.gameObject.SetActive(true);
        }
    }
    void ClickButtonUpgrade()
    {
        int upgradeCost = dataWeapon.soWeapon.upgradeCosts[dataWeapon.currentLevel - 1];
        if (savingSystem.UpgradeWeapon(soWeapon.weaponName, upgradeCost))
        {
            if (dataWeapon.currentLevel == dataWeapon.soWeapon.maxLevel)
            {
                txtCost.gameObject.SetActive(false);
                btnUpgrade.gameObject.SetActive(false);
                txtLevel.text = "Level: " + dataWeapon.currentLevel.ToString() + " (MAX)";
            }
            else
            {
                txtCost.text = "Cost: " + dataWeapon.soWeapon.upgradeCosts[dataWeapon.currentLevel-1].ToString();
                txtLevel.text = "Level: " + dataWeapon.currentLevel.ToString();
            }
        }
    }


}
