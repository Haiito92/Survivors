using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Scripts.Inventory
{
    using SO.Scripts.Weapon;
    using Weapons;
    
    public class Inventory : MonoBehaviour
    {
        //Weapon Inventory
        [SerializeField] private List<Weapon> _weaponInventory = new List<Weapon>();
        [SerializeField] private int _weaponInventorySize;

        //Temp (remove that after instantiate tests)
        [SerializeField] private WeaponSO _testWeaponSO;
        
        private void Start()
        {
            AddWeapon(_testWeaponSO);
        }

        private void Update()
        {
            foreach (Weapon weapon in _weaponInventory)
            {
                weapon.CheckTimer();
            }
        }

        private void AddWeapon(WeaponSO weaponSo)
        {
            GameObject poolParent = Instantiate(new GameObject($"{weaponSo.WeaponName} Pool"), transform);
            _weaponInventory.Add(new Weapon(weaponSo, poolParent.transform));
        }
    }
}
