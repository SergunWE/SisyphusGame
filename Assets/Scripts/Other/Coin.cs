using System;
using UnityEngine;
using YandexSDK.Scripts;
using Random = System.Random;

namespace SkibidiRunner.Managers
{
    public class Coin : MonoBehaviour
    {
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
                var transform1 = transform;
                transform1.parent = null;
                transform1.localScale = Vector3.one;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            LocalYandexData.Instance.SaveInfo.Coins++;
            gameObject.SetActive(false);
        }
    }
}