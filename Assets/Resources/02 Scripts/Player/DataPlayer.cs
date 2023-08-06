using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataPlayer
{
    public int coin;
    [Space(5)]
    public List<DataWeapon> dataWeapons = new List<DataWeapon>();

}
