using System.Collections;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        //Weapon State and Type
        private bool _isActivated;
        
        //Bullet Prefab
        private GameObject _bullet;
        
        //Weapon stats
        private float _attackSpeed;
                
        //Coroutines
        private Coroutine _shoot;

        #region Properties

        public bool IsActivated
        {
            get => _isActivated;
            set => _isActivated = value;
        }
        
        #endregion
        
        private void Start()
        {
            _shoot = StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            if (_isActivated)
            {
                Debug.Log("Shoot");
            }
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}
