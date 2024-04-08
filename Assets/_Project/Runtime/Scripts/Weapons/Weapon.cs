using _Project.Runtime.SO.Scripts.Weapon;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    [System.Serializable]
    public class Weapon
    {
        //Weapon stats
        [SerializeField] private float _attackSpeed;
        
        //Weapon Timer
        private float _weaponTimer;
        
        //Pool
        private Pool _weaponPool;
        
        //Bullet Prefab
        [SerializeField] private GameObject _bullet;

        public Weapon(WeaponSO weaponSo, Transform poolParent)
        {
            _attackSpeed = weaponSo.BaseAttackSpeed;
            
            _weaponPool = new Pool(poolParent);

            _bullet = weaponSo.BulletPrefab;
        }
        
        public void CheckTimer()
        {
            _weaponTimer += Time.deltaTime;

            if (_weaponTimer >= _attackSpeed)
            {
                Shoot();
                _weaponTimer = 0;
            }
        }

        private void Shoot()
        {
            _weaponPool.InstantiateObject(_bullet);
        }
    }
}
