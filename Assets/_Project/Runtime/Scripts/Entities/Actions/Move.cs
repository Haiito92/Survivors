using System;
using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Actions
{
    public class Move : MonoBehaviour
    {
        //Components References
        [SerializeField] private Rigidbody2D _rb;
    
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
        }

        public void SetDirection(Vector2 dir)
        {
            _oldDirection = _direction;
            _direction = dir;
            
            Flip();
            
            OnDirectionChanged?.Invoke(_oldDirection, _direction);
        }
        
        private void Walking()
        {
            _rb.velocity = _direction.normalized * _speed;
        }

        private void Flip()
        {
            if ((_direction.x < 0 && _isFacingRight) || (_direction.x > 0 && !_isFacingRight))
            {
                _rb.transform.Rotate(0f,180f,0f ); 
                
                _isFacingRight = !_isFacingRight;
            }
        }
    }
}
