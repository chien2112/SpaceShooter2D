using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    [SerializeField] public SOWeapon soWeapon;

    [SerializeField] private Player player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SavingSystem savingSystem;
    private void Awake()
    {
       
    }
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

        gameObject.name = soWeapon.weaponName;
        image.sprite = soWeapon.sprite;
        txtName.text = soWeapon.weaponName;
        txtPrice.text = "Price: " + soWeapon.price.ToString();
        txtCost.text = "Cost: " + soWeapon.upgradeCost.ToString();
        txtLevel.text = "Level: 0";

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

        playerData = SavingSystem.Instance.playerData;
        savingSystem = SavingSystem.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (playerData.weapons.Contains(soWeapon.name))
        {
            btnUnequip.gameObject.SetActive(true);
        }
        else
        {
            btnEquip.gameObject.SetActive(true);
        }
    }
    void ClickButtonEquip()
    {
        savingSystem.AddWeapon(soWeapon.name);
        savingSystem.LoadWeaponList();
        btnEquip.gameObject.SetActive(false);
        btnUnequip.gameObject.SetActive(true);
    }
    void ClickButtonUnequip()
    {
        savingSystem.RemoveWeapon(soWeapon.name);
        savingSystem.LoadWeaponList();
        btnEquip.gameObject.SetActive(true);
        btnUnequip.gameObject.SetActive(false);
    }
    void ClickButtonBuy()
    {
    }
    void ClickButtonUpgrade()
    {
    }

   
}
