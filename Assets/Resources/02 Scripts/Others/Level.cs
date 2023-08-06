using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public bool isClear;
    void Awake()
    {
        var result = FindObjectsOfType<Level>();
        foreach (var lv in result)
        {
            if (lv != this)
                Destroy(lv.gameObject);
        }
        isClear = false;
    }
}
