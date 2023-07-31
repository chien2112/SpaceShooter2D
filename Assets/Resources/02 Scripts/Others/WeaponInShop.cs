using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponInShop : MonoBehaviour
{
    public GameObject weapon;
    private Button btnEquip;

    private void Awake()
    {
        foreach(Transform t in transform)
        {
            if(t.name == "btnEquip")
            {
                btnEquip = t.GetComponent<Button>();
                btnEquip.onClick.AddListener(ClickButtonEquip);
                
            }
        }
    }

    void ClickButtonEquip()
    {
        PlayerData.Instance.AddWeapon(weapon.GetComponent<Weapon>());
        btnEquip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equipped";
    }
}
