using _Project.Runtime.Scripts.Pool;
using UnityEngine;

namespace _Project.Runtime.Scripts.Weapons.Bullets
{
    public interface IBullet : IPoolable
    {
        public void InitializeBullet();
    }
}
