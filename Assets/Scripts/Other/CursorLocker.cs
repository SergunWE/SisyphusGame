using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class CursorLocker : MonoBehaviour
    {
        private bool _disableLock;

        private void Awake()
        {
            SetCursorState(true);
        }

        public void SetCursorState(bool state)
        {
            if (_disableLock)
            {
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void DisableLock()
        {
            _disableLock = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            //SetCursorState(_lock);
        }
    }
}