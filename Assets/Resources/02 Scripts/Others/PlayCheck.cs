using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayCheck : Singleton<PlayCheck>
{
    public TextMeshProUGUI txtNotification;
    public bool Check()
    {
        foreach(var weapon in SavingSystem.Instance.dataPlayer.dataWeapons)
        {
            if (weapon.isEquipped)
            {
                return true;
            }
        }
        return false;
    }
    public void Notification()
    {
        txtNotification.gameObject.SetActive(true);
    }
}
