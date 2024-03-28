using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Runtime.Scripts.Entities.Brains.Player
{
    using Actions;
    
    public class PlayerBrain : EntityBrain
    {
        //Input Action References
        [Header("INPUT ACTION REFERENCES")]
        
        [SerializeField] private InputActionReference _walkInputAction;

        private void GetInput(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                SetWalkDirection(ctx.ReadValue<Vector2>());
            }
            else if (ctx.canceled)
            {
                SetWalkDirection(Vector2.zero);
            }
        }
    
        private void OnEnable()
        {
            _walkInputAction.action.performed += GetInput;
            _walkInputAction.action.canceled += GetInput;
        }

        private void OnDisable()
        {
            _walkInputAction.action.performed -= GetInput;
            _walkInputAction.action.canceled -= GetInput;
        }
    }
}
