using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Runtime.Scripts.Entities.Brains
{
    using Actions;
    using Weapons;
    
    public class PlayerBrain : MonoBehaviour
    {
        //Input Action References
        [Header("INPUT ACTION REFERENCES")]
        
        [SerializeField] private InputActionReference _walkInputAction;
    
        //Components References
        [Space, Header("COMPONENT REFERENCES")]
        [Space(1f), Header("Action Components")]
        
        [SerializeField] private Walk _walk;

        [SerializeField] private Inventory _inventory;

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
