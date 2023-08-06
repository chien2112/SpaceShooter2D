using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SOLevelManager SOLevelManager;
    public Transform levelBoard;
    public GameObject buttonLevelPrefab;

    private void Awake()
    { 
        var result = FindObjectsOfType<Level>();
        foreach (var lv in result)
        {
            if (lv != this)
                Destroy(lv.gameObject);
        }
        Init();
    }

    private void Init()
    {
        Transform levelGroup = FindGameObject.FindChildGameObjectByName(levelBoard, "LevelGroup");
        foreach(GameObject lv in SOLevelManager.levels)
        {
            GameObject btn = Instantiate(buttonLevelPrefab, levelGroup);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = lv.name;
        }
    }
}
