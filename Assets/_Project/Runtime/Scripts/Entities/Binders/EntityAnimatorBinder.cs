using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Binders
{
    using Actions;
    
    [RequireComponent(typeof(Animator))]
    public class EntityAnimatorBinder : MonoBehaviour
    {
        //Referenced Components
        [SerializeField] private Animator _animator;
        [SerializeField] private Walk _walk;

        //Override Controller
        [SerializeField] private AnimatorOverrideController _controller;
        
        //Animator Params
        [SerializeField, AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)] private string _isWalkingBoolParam;
        
        private void Reset()
        {
            _animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            _animator.runtimeAnimatorController = _controller;
        }

        private void SetWalkingParams(Vector2 oldDirection, Vector2 currentDirection)
        {
            _animator.SetBool(_isWalkingBoolParam, currentDirection != Vector2.zero);
        }
        
        private void OnEnable()
        {
            _walk.OnDirectionChanged += SetWalkingParams;
        }

        private void OnDisable()
        {
            _walk.OnDirectionChanged -= SetWalkingParams;
        }
    }
}
