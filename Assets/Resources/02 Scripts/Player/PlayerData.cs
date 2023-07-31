
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    public List<Weapon> weapons = new List<Weapon>();
    private void Awake()
    {
        var result = FindObjectsOfType<PlayerData>();
        foreach (var data in result)
        {
            if (data != this)
                Destroy(data.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void AddWeapon(Weapon wp)
    {
        weapons.Add(wp);
    }
}
