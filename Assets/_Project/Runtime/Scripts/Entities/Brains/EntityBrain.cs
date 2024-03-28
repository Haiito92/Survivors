using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Runtime.Scripts.Entities.Brains
{
    using Actions;
    
    public abstract class EntityBrain : MonoBehaviour
    {
        //Components References
        [FormerlySerializedAs("_walk")]
        [Space, Header("COMPONENT REFERENCES")]
        [Space(1f), Header("Action Components")]
        
        [SerializeField] protected Move _move;

        protected void SetWalkDirection(Vector2 direction)
        {
            _move.SetDirection(direction);
        }
    }
}
