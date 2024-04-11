using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Scripts.Pool
{
    public class Pool<T> where T : IPoolable
    {
        private Transform _poolParent;
        private Dictionary<GameObject, T> _poolObjects;

        public Pool(Transform poolParent)
        {
            _poolParent = poolParent;

            _poolObjects = new Dictionary<GameObject, T>();
        }

        public T InstantiateObject(GameObject prefab)
        {
            if (HasAvailableObject(out GameObject availableObject))
            {
                availableObject.SetActive(true);
                
                _poolObjects[availableObject].ResetPoolable();
                
                return _poolObjects[availableObject];
            }
        
            return CreateNewObject(prefab);
        }
    
        private bool HasAvailableObject(out GameObject availableObject)
        {
            availableObject = default;
        
            foreach (GameObject poolObject in _poolObjects.Keys)
            {
                if (poolObject.activeSelf == false)
                {
                    availableObject = poolObject;
                    return true;
                }
            }

            return false;
        }

        private T CreateNewObject(GameObject prefab)
        {
            GameObject createdGO = GameObject.Instantiate(prefab, _poolParent);

            T createdComponent = createdGO.GetComponent<T>();
            
            _poolObjects.Add(createdGO, createdComponent);

            return createdComponent;
        }
    }
}
