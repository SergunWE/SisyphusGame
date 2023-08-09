using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class WinCollider : MonoBehaviour
    {
        [SerializeField] private GameEvents gameEvents;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.body.CompareTag("Stone"))
            {
                gameEvents.gameWin?.Invoke();
            }
        }
    }
}