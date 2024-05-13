using System;
using _Project.Runtime.Scripts.Pool;
using _Project.Runtime.Scripts.Utilities;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        //Setup
        [SerializeField] private Rigidbody2D _rb;
    
        //Bullet Stat
        [SerializeField] private float _bulletSpeed;

        public void InitializeBullet()
        {
            _rb.velocity = transform.right * _bulletSpeed;
        }

        #region IPoolable

        public void InitPoolable(Vector2 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        #endregion
        
    }
}
