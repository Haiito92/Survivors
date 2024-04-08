using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    [System.Serializable]
    public class Weapon
    {
        //Bullet Prefab
        [SerializeField] private GameObject _bullet;
        
        //Pool
        private Pool _weaponPool;
        
        //Weapon Timer
        private float _weaponTimer;
        
        //Weapon stats
        [SerializeField] private float _attackSpeed;

        public Weapon(Transform poolParent, GameObject bulletPrefab)
        {
            _weaponPool = new Pool(poolParent);
            
            _bullet = bulletPrefab;

            _attackSpeed = 2;
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
