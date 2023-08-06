using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameObject : MonoBehaviour
{
    public static Transform FindChildGameObjectByName(Transform parent, string name)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).name == name)
            {
                return parent.GetChild(i);
            }
            Transform child = FindChildGameObjectByName(parent.GetChild(i), name);
            if (child != null)
            {
                return child;
            }
        }
        return null;
    }
}
