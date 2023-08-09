﻿using System;
using UnityEngine;
using YandexSDK.Scripts;
using Random = System.Random;

namespace SkibidiRunner.Managers
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private bool deleteParent = true;
        [SerializeField] private AudioClip gettingSound;
        [SerializeField, Range(0,1)] private float spawnChance;

        private static readonly Random Random;

        static Coin()
        {
            Random = new Random(DateTime.UtcNow.Millisecond);
        }
        
        private void Awake()
        {
            double random = Random.NextDouble();
            if (random > spawnChance)
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (!deleteParent) return;
                var transform1 = transform;
                transform1.parent = null;
                transform1.localScale = Vector3.one;
                transform1.rotation = Quaternion.identity;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(gettingSound);
            }
            LocalYandexData.Instance.SaveInfo.Coins++;
            GameInfo.Instance.CoinCount++;
            gameObject.SetActive(false);
        }
    }
}