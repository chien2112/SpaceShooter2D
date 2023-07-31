using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SOLevelManager SOLevelManager;

    private void Awake()
    {
        var result = FindObjectsOfType<Level>();
        foreach (var lv in result)
        {
            if (lv != this)
                Destroy(lv.gameObject);
        }
    }   
}
