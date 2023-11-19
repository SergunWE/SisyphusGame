using System;
using UnityEngine;
using UnityEngine.Events;

namespace Clickers
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class ClickerTrigger : MonoBehaviour
    {
        [SerializeField] private string playerTag;
        [SerializeField] private UnityEvent playerCame;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(playerTag)) return;
            playerCame?.Invoke();
        }
    }
}