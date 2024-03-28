using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons
{
    using Entities.Actions;
    
    public class Bullet : MonoBehaviour
    {
        //Ref to components
        [SerializeField] private Move _move;

        public void InitializeBullet(Vector2 startingDirection)
        {
            _move.SetDirection(startingDirection);
        }
    }
}
