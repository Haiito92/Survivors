using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Runtime.Scripts.Entities.Binders
{
    using Actions;
    
    [RequireComponent(typeof(Animator))]
    public class EntityAnimatorBinder : MonoBehaviour
    {
        //Referenced Components
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _sp;
        [SerializeField] private Move _move;

        //Override Controller
        [SerializeField] private AnimatorOverrideController _controller;
        
        //Animator Params
        [SerializeField, AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)] private string _isWalkingBoolParam;
        
        //FacingDir
        private bool _isFacingRight = true;
        
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
            Flip(currentDirection);
        }
        
        private void Flip(Vector2 direction) 
        {
            if (direction.x < 0 && _isFacingRight)
            {
                _sp.flipX = true;
            }
            else if (direction.x > 0 && !_isFacingRight)
            {
                _sp.flipX = false;
            }

            _isFacingRight = !_isFacingRight;
        }
        
        private void OnEnable()
        {
            _move.OnDirectionChanged += SetWalkingParams;
        }

        private void OnDisable()
        {
            _move.OnDirectionChanged -= SetWalkingParams;
        }
    }
}
