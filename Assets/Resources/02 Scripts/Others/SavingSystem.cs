using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SavingSystem : Singleton<SavingSystem>
{
    [SerializeField] private string path = "";
    [SerializeField] private string persistentPath = "";
    [Space(10)]
    [SerializeField] private List<SOWeapon> soWeapons = new List<SOWeapon>();
    [Space(10)]
    public DataPlayer dataPlayer;
    private Player player;
    private Transform weaponHolder;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weaponHolder = player.transform.GetChild(0);
        SetPaths();
        InitDataWeapon();
        LoadData();
    }
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(dataPlayer,true);
        File.WriteAllText(path, json);
    }
    public void LoadData()
    {
        string json = File.ReadAllText(path);
        if (json != "")
        {
            dataPlayer = JsonUtility.FromJson<DataPlayer>(json);
        }
        else
        {
            //InitDataWeapon();
            SaveData();
        }

    }
    void InitDataWeapon()
    {
        dataPlayer.isNewPlayer = true;
        foreach (SOWeapon soWeapon in soWeapons)
        {
            DataWeapon dataWeapon = new DataWeapon();
            dataWeapon.name = soWeapon.weaponName;
            dataWeapon.currentLevel = 1;
            dataWeapon.soWeapon = soWeapon;
            dataWeapon.isUnlocked = false;
            dataWeapon.isEquipped = false;
            dataPlayer.dataWeapons.Add(dataWeapon);
        }
    }
    public bool UsingCoin(int value)
    {
        dataPlayer.coin -= value;
        if (dataPlayer.coin < 0)
        {
            dataPlayer.coin += value;
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool BuyWeapon(string weaponName, int price)
    {
        if (UsingCoin(price))
        {
            DataWeapon dataWeapon = GetDataWeaponByName(weaponName);
            dataWeapon.isUnlocked = true;
            dataWeapon.isEquipped = false;
            ShopManager.Instance.UpdateCoinText();
            return true;
        }
        return false;
    }
    public bool UpgradeWeapon(string weaponName, int cost)
    {
        if (UsingCoin(cost))
        {
            DataWeapon dataWeapon = GetDataWeaponByName(weaponName);
            if (dataWeapon.currentLevel < dataWeapon.soWeapon.maxLevel)
            {
                dataWeapon.currentLevel++;
                ShopManager.Instance.UpdateCoinText();
                return true;
            }
        }
        return false;
    }
    public void EquipWeapon(string weaponName)
    {
        DataWeapon dataWeapon = GetDataWeaponByName(weaponName);
        dataWeapon.isEquipped = true;
        LoadWeapon();
    }
    public void UnequipWeapon(string weaponName)
    {
        DataWeapon dataWeapon = GetDataWeaponByName(weaponName);
        dataWeapon.isEquipped = false;
        LoadWeapon();
    }
    public void LoadWeapon()
    {
        foreach (DataWeapon data in dataPlayer.dataWeapons)
        {
            if (data.isEquipped)
            {
                weaponHolder.Find(data.soWeapon.weaponName).gameObject.SetActive(true);
                Weapon weapon = weaponHolder.Find(data.soWeapon.weaponName).GetComponent<Weapon>();
                player.weapons.Add(weapon);
                weapon.Init();
            }
            else
            {
                weaponHolder.Find(data.soWeapon.weaponName).gameObject.SetActive(false);
            }
        }
    }

    public DataWeapon GetDataWeaponByName(string weaponName)
    {
        foreach (DataWeapon dataWeapon in dataPlayer.dataWeapons)
        {
            if (dataWeapon.name == weaponName)
            {
                return dataWeapon;
            }
        }
        return null;
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }

    #region TESTING
    public void MaximumCoin()
    {
        dataPlayer.coin = 999999;
        ShopManager.Instance.UpdateCoinText();
    }
    public void ResetData()
    {
        dataPlayer.dataWeapons.Clear();
        dataPlayer.coin = 0;
        InitDataWeapon();
        SaveData();
        LoadData();
        LoadWeapon();
        ShopManager.Instance.Init();
    }
    #endregion
}
