using System;
using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Brains.Monsters
{
    using Actions;
    
    public class MonsterBrain : EntityBrain
    {
        //Target
        [Space(1f), Header("Target Components")] 
        
        [SerializeField] private Transform _target;

        private void Update()
        {
            GetDirection();
        }

        private void GetDirection()
        {
            Vector2 direction = _target.position - transform.position;
            direction.Normalize();
            
            SetWalkDirection(direction);
        }
    }
}
