﻿using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    [RequireComponent(typeof(Rigidbody))]
    public class SavePoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || GameInfo.Instance == null) return;
            GameInfo.Instance.PlayerSavePoint = transform;
            gameObject.SetActive(false);
        }
    }
}