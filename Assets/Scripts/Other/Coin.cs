using System;
using UnityEngine;
using YandexSDK.Scripts;
using Random = System.Random;

namespace SkibidiRunner.Managers
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private bool deleteParent = true;
        [SerializeField, Range(0,1)] private float spawnChance;

        private static readonly Random Random;

        static Coin()
        {
            Random = new Random((int)DateTime.UtcNow.Ticks);
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
            GameEvents.Instance.CoinCollected();
            gameObject.SetActive(false);
        }
    }
}