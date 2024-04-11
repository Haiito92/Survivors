using System;
using _Project.Runtime.Scripts.Pool;
using _Project.Runtime.Scripts.Utilities;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour, IBullet, IPoolable
    {
        //Setup
        [SerializeField] private Rigidbody2D _rb;
    
        //Bullet Stat
        [SerializeField] private float _bulletSpeed;
    
    
        void Start()
        {
            InitializeBullet();
        }

        public void InitializeBullet()
        {
            transform.position = Vector3.zero;
            _rb.velocity = transform.right * _bulletSpeed;
        }

        public void ResetPoolable()
        {
            InitializeBullet();
        }
    }
}
