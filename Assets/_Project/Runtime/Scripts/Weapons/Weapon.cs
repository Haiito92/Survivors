using _Project.Runtime.Scripts.Pool;
using _Project.Runtime.Scripts.Weapons.Bullets;
using _Project.Runtime.SO.Scripts.Weapon;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    [System.Serializable]
    public class Weapon
    {
        //OwnerPlayer
        private Transform _ownerTransform;
        
        //Weapon stats
        [SerializeField] private float _attackSpeed;
        
        //Weapon Timer
        private float _weaponTimer;
        
        //Pool
        private Pool<Bullet> _weaponPool;
        
        //Bullet Prefab
        [SerializeField] private GameObject _bullet;

        public Weapon(WeaponSO weaponSo, Transform ownerTransform, Transform poolParent)
        {
            _ownerTransform = ownerTransform;
            
            _attackSpeed = weaponSo.BaseAttackSpeed;
            
            _weaponPool = new Pool<Bullet>(poolParent);

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
            Bullet bullet = _weaponPool.InstantiateObject(_bullet, _ownerTransform.position, _ownerTransform.rotation);
            bullet.InitializeBullet();           
        }
    }
}
