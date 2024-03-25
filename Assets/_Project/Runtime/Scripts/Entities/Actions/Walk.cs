using UnityEngine;

namespace _Project.Runtime.Scripts.Entities.Actions
{
    public class Walk : MonoBehaviour
    {
        //Components References
        [SerializeField] private Transform _movedTransform;
    
        //Fields
        private Vector2 _direction;
    
        private Vector2 _velocity;
        [SerializeField] private float _speed;

        #region Properties

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

        private void Walking()
        {
            _velocity = _direction.normalized * _speed;

            _movedTransform.position = (Vector2)_movedTransform.position + _velocity * Time.fixedDeltaTime;
        }
    }
}
