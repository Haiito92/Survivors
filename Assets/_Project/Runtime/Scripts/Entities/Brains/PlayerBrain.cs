using _Project.Runtime.Scripts.Entities.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Runtime.Scripts.Entities.Brains
{
    public class PlayerBrain : MonoBehaviour
    {
        //Input Action References
        [Header("INPUT ACTION REFERENCES")]
        [SerializeField] private InputActionReference _walkInputAction;
    
        //Components References
        [Space, Header("COMPONENT REFERENCES")]
        [Space(1f), Header("Action Components")]
        [Tooltip("Ceci est un tooltip"), SerializeField] private Walk _walk;

        private void SetWalkDirection(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _walk.Direction = ctx.ReadValue<Vector2>();
            }
            else if (ctx.canceled)
            {
                _walk.Direction = Vector2.zero;
            }
        
        }
    
        private void OnEnable()
        {
            _walkInputAction.action.started += SetWalkDirection;
            _walkInputAction.action.canceled += SetWalkDirection;
        }

        private void OnDisable()
        {
            _walkInputAction.action.started -= SetWalkDirection;
            _walkInputAction.action.canceled -= SetWalkDirection;
        }
    }
}
