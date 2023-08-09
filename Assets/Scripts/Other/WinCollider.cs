using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class WinCollider : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.body.CompareTag("Stone"))
            {
                GameEvents.Instance.WinGame();
            }
        }
    }
}