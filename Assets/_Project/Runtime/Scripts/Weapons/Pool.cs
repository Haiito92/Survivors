using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Transform _poolParent;
    private List<GameObject> _poolObjects;

    public Pool(Transform poolParent)
    {
        _poolParent = poolParent;

        _poolObjects = new List<GameObject>();
    }

    public void InstantiateObject(GameObject prefab)
    {
        if (HasAvailableObject(out GameObject availableObject))
        {
            availableObject.SetActive(true);
            return;
        }
        
        CreateNewObject(prefab);
    }
    
    private bool HasAvailableObject(out GameObject availableObject)
    {
        availableObject = null;
        
        foreach (GameObject poolObject in _poolObjects)
        {
            if (poolObject.activeSelf == false)
            {
                availableObject = poolObject;
                return true;
            }
        }

        return false;
    }

    private void CreateNewObject(GameObject prefab)
    {
        _poolObjects.Add(GameObject.Instantiate(prefab, _poolParent));
    }
}
