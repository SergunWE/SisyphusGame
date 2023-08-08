using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public abstract class MonoBehaviourInitializable : MonoBehaviour
    {
        public abstract void Initialize();

        protected virtual void OnEnable()
        {
            LocalYandexData.Instance.OnYandexDataLoaded += OnYandexDataLoaded;
        }
        
        protected virtual void OnDisable()
        {
            LocalYandexData.Instance.OnYandexDataLoaded -= OnYandexDataLoaded;
        }

        protected virtual void OnYandexDataLoaded()
        {
            Initialize();
        }
    }
}