using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class CursorLocker : MonoBehaviour
    {
        private bool _currentState;
        
        private void Awake()
        {
            _currentState = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        public void SetCursorState(bool state)
        {
            _currentState = state;
            Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(_currentState);
        }
    }
}