using System;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour
    {
        //Setup
        [SerializeField] private Rigidbody2D _rb;
    
        //Bullet Stat
        [SerializeField] private float _bulletSpeed;
    
    
        void Start()
        {
            _rb.velocity = transform.right * _bulletSpeed;
        }

        private void FixedUpdate()
        {
            if (!IsBulletOnScreen())
            {
                gameObject.SetActive(false);
            }
        }

        private bool IsBulletOnScreen()
        {
            Rect rect = CameraUtilities.GetCamWorldBoundingBox();
            return true;
        }
    }
}
