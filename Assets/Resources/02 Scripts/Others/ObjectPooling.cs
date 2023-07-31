using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPooling : MonoBehaviour
{
    static Dictionary<string, List<GameObject>> dicPool = new Dictionary<string, List<GameObject>>();

    public static GameObject GetGameObjectFromPool(string objectName, Vector3 position, string path)
    {
        if (dicPool.ContainsKey(objectName) == false)
        {
            dicPool.Add(objectName, new List<GameObject>());
        }
        List<GameObject> pool = dicPool[objectName];

        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].transform.position = position;
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject src = Resources.Load<GameObject>(path);
        GameObject newObj = Instantiate(src, position, Quaternion.identity);
        pool.Add(newObj);
        return newObj;
    }
    public static GameObject GetGameObjectFromPool(string objectName, string path)
    {
        if (dicPool.ContainsKey(objectName) == false)
        {
            dicPool.Add(objectName, new List<GameObject>());
        }

        List<GameObject> pool = dicPool[objectName];

        for (int i = 0; i < pool.Count; i++)
        {

            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject src = Resources.Load<GameObject>(path);
        GameObject newObj = Instantiate(src);
        pool.Add(newObj);
        return newObj;
    }
    public static GameObject GetGameObjectFromPool(GameObject go, Vector3 position)
    {
        if (dicPool.ContainsKey(go.name) == false)
        {
            dicPool.Add(go.name, new List<GameObject>());
        }

        List<GameObject> pool = dicPool[go.name];

        for (int i = 0; i < pool.Count; i++)
        {

            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = position;
                return pool[i];
            }
        }
        
        GameObject newObj = Instantiate(go);
        newObj.transform.position = position;
        pool.Add(newObj);
        return newObj;
    }
    public static void ClearDic()
    {
        dicPool.Clear();
    }

}
