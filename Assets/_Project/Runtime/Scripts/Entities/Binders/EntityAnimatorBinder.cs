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
        [SerializeField, AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Float)] private string _horizontalFloatParam;
        [SerializeField, AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Float)] private string _verticalFloatParam;
        
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

            if (currentDirection == Vector2.zero)
            {
                _animator.SetFloat(_horizontalFloatParam, oldDirection.x);
                _animator.SetFloat(_verticalFloatParam, oldDirection.y);
                return;
            }
            
            _animator.SetFloat(_horizontalFloatParam, currentDirection.x);
            _animator.SetFloat(_verticalFloatParam, currentDirection.y);
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
