using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Runtime.Scripts.Weapons;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    //Weapon Inventory
    private Weapon[] _weaponInventory;
    [SerializeField] private int _weaponInventorySize;
    
    //Weapon Prefab
    [SerializeField] private GameObject _weaponController;
    [SerializeField] private Transform _weaponsParent;

    private void Awake()
    {
        _weaponInventory = new Weapon[_weaponInventorySize];
        for (int i = 0; i < _weaponInventory.Length; i++)
        {
            GameObject go = Instantiate(_weaponController, _weaponsParent);
            _weaponInventory[i] = go.GetComponent<Weapon>();
        }
    }
}
