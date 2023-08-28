using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public abstract class MonoBehaviourInitializable : MonoBehaviour
    {
        [SerializeField] private bool useLoadableData;

        protected abstract void Initialize();

        public void TryInitialize()
        {
            if (useLoadableData)
            {
                if (LocalYandexData.Instance.YandexDataLoaded)
                {
                    Initialize();
                }
            }
            else
            {
                Initialize();
            }
        }

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