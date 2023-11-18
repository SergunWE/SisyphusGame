using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class WinCollider : MonoBehaviour
    {
        [SerializeField] private string checkTag;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == checkTag)
            {
                GameEvents.Instance.WinGame();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == checkTag)
            {
                GameEvents.Instance.WinGame();
            }
        }
    }
}