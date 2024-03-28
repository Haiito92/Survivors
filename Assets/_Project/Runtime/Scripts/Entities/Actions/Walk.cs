using System;
using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Actions
{
    public class Walk : MonoBehaviour
    {
        //Components References
        [SerializeField] private Transform _movedTransform;
        [SerializeField] private SpriteRenderer _sp;
    
        //Directions
        private Vector2 _oldDirection;
        private Vector2 _direction;
    
        private Vector2 _velocity;
        [SerializeField] private float _speed;
        
        //FacingDir
        private bool _isFacingRight = true;
        
        //Actions

        public event Action<Vector2, Vector2> OnDirectionChanged;
        
        #region Properties

        public Vector2 OldDirection
        {
            get => _oldDirection;
            set => _oldDirection = value;
        }
        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }


        #endregion

        private void FixedUpdate()
        {
            Walking();
            Flip();
        }

        public void SetDirection(Vector2 dir)
        {
            _oldDirection = _direction;
            _direction = dir;
            
            OnDirectionChanged?.Invoke(_oldDirection, _direction);
        }
        
        private void Walking()
        {
            _velocity = _direction.normalized * _speed;

            _movedTransform.position = (Vector2)_movedTransform.position + _velocity * Time.fixedDeltaTime;
        }

        private void Flip() 
        {
            if (_direction.x < 0 && _isFacingRight)
            {
                _sp.flipX = true;
            }
            else if (_direction.x > 0 && !_isFacingRight)
            {
                _sp.flipX = false;
            }

            _isFacingRight = !_isFacingRight;
        }
    }
}
