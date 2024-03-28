using System.Collections;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        //Weapon State and Type
        
        //Bullet Prefab
        private GameObject _bullet;
        
        //Weapon stats
        private float _attackSpeed;
                
        //Coroutines
        private Coroutine _shoot;

        private void Start()
        {
            _shoot = StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}
