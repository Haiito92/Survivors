using System;
using UnityEngine;

namespace _Project.Runtime.SO.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "New Weapon SO", menuName = "ScriptableObjects/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        //General Infos
        [field : SerializeField] public string WeaponName { get; private set; }
        [field : SerializeField] public string Description { get; private set; }
        
        //BaseStats
        [field : SerializeField] public float BaseAttackSpeed { get; private set; }
        
        //WeaponType
        
        //Bullet
        [field : SerializeField] public GameObject BulletPrefab { get; private set; }
    }
}
