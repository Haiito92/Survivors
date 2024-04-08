using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Scripts.Inventory
{
    using Weapons;
    
    public class Inventory : MonoBehaviour
    {
        //Weapon Inventory
        [SerializeField] private List<Weapon> _weaponInventory = new List<Weapon>();
        [SerializeField] private int _weaponInventorySize;

        //Temp (remove that after instantiate tests)
        [SerializeField] private GameObject _bulletPrefab;
        
        private void Start()
        {
            GameObject poolParent = Instantiate(new GameObject("WeaponPool"), transform);
            _weaponInventory.Add(new Weapon(poolParent.transform, _bulletPrefab));
        }

        private void Update()
        {
            foreach (Weapon weapon in _weaponInventory)
            {
                weapon.CheckTimer();
            }
        }
    }
}
