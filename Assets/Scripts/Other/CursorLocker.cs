using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class CursorLocker : MonoBehaviour
    {
        private bool _lock;
        
        private void Awake()
        {
            SetCursorState(true);
        }
        
        public void SetCursorState(bool state)
        {
            _lock = state;
            Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(_lock);
        }
    }
}