using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SavingSystem : Singleton<SavingSystem>
{
    //private string path = "";
    public string persistentPath = "";
    public PlayerData playerData;
    public Player player;
    public Transform weaponHolder;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weaponHolder = player.transform.GetChild(0);
        
        SetPaths();
        LoadData();
        LoadWeaponList();
    }

    private void SetPaths()
    {
        //path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        Debug.Log("save " + json);
        File.WriteAllText(persistentPath, json);
    }
    public void LoadData()
    {
        string json = File.ReadAllText(persistentPath);
        Debug.Log("load " + json);
        playerData = JsonUtility.FromJson<PlayerData>(json);
    }
    public void AddWeapon(string weaponName)
    {
        if (!playerData.weapons.Contains(weaponName))
        {
            playerData.weapons.Add(weaponName);   
        }
    }
    public void RemoveWeapon(string weaponName)
    {
        playerData.weapons.Remove(weaponName);
        player.weapons.Remove(weaponHolder.Find(weaponName).GetComponent<Weapon>());
    }
    public void ClearWeapon()
    {
        playerData.weapons.Clear();
    }
    public void LoadWeaponList()
    {
        player.weapons.Clear();
        foreach (Transform t in weaponHolder)
        {
            t.gameObject.SetActive(false);
        }
        foreach (string weaponName in playerData.weapons)
        {
            weaponHolder.Find(weaponName).gameObject.SetActive(true);
            player.weapons.Add(weaponHolder.Find(weaponName).GetComponent<Weapon>());
        }
    }
    
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
