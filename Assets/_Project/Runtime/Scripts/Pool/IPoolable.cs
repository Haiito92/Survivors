using UnityEngine;

namespace _Project.Runtime.Scripts.Pool
{
    public interface IPoolable
    {
        public void InitPoolable(Vector2 position, Quaternion rotation = default);
    }
}
