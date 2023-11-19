using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    [RequireComponent(typeof(Rigidbody))]
    public class SavePoint : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(playerTag) || GameInfo.Instance == null) return;
            GameInfo.Instance.PlayerSavePoint = transform;
            gameObject.SetActive(false);
        }
    }
}