using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AR_PROTO
{
    public class InputManager : MonoBehaviour
    {
        private InputController _inputController;

        protected void Awake()
        {
            _inputController = new InputController();
        }

        protected void OnEnable()
        {
            _inputController.Enable();
        }

        protected void OnDisable()
        {
            _inputController.Disable();
        }

        protected void Start()
        {
            _inputController.Touch.TouchPress.started += context => StartTouch(context);
            _inputController.Touch.TouchPress.canceled += context => EndTouch(context);
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            Debug.Log("Touch started" + context.ReadValue<float>());
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}
