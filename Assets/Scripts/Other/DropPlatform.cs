﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SkibidiRunner.Managers
{
    public class DropPlatform : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        [SerializeField] private Animation objectAnimation;
        [SerializeField, Range(0,1)] private float speed;

        private void Awake()
        {
            objectAnimation["DropPlatform"].speed = speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(playerTag)) return;
            objectAnimation.Stop();
            objectAnimation.Play();
        }
    }
}