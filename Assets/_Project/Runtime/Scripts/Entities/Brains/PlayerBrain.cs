using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Runtime.Scripts.Entities.Brains
{
    using Actions;
    
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
            if (ctx.performed)
            {
                _walk.SetDirection(ctx.ReadValue<Vector2>());
            }
            else if (ctx.canceled)
            {
                _walk.SetDirection(Vector2.zero);
            }
        
        }

        private void DebugInput(InputAction.CallbackContext ctx)
        {
            if(ctx.started) Debug.Log(("started"));
            if(ctx.canceled) Debug.Log(("canceled"));
            
        }
    
        private void OnEnable()
        {
            _walkInputAction.action.performed += SetWalkDirection;
            _walkInputAction.action.canceled += SetWalkDirection;
        }

        private void OnDisable()
        {
            _walkInputAction.action.performed -= SetWalkDirection;
            _walkInputAction.action.canceled -= SetWalkDirection;
        }
    }
}
