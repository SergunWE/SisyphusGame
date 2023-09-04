using System;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class PauseInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent pause;
        
        public void OnPauseClicked(InputAction.CallbackContext obj)
        {
            if(GameEvents.Instance.GameLost || GameEvents.Instance.GameLost) return;
            pause?.Invoke();
        }
    }
}