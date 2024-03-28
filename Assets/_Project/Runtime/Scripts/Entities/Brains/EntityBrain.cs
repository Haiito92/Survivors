using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Brains
{
    using Actions;
    
    public abstract class EntityBrain : MonoBehaviour
    {
        //Components References
        [Space, Header("COMPONENT REFERENCES")]
        [Space(1f), Header("Action Components")]
        
        [SerializeField] protected Walk _walk;

        protected void SetWalkDirection(Vector2 direction)
        {
            _walk.SetDirection(direction);
        }
    }
}
