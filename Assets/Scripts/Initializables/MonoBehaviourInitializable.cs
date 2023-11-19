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
            try
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
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        protected virtual void OnEnable()
        {
            LocalYandexData.Instance.OnYandexDataLoaded.Add(this);
        }

        protected virtual void OnDisable()
        {
            LocalYandexData.Instance.OnYandexDataLoaded.Remove(this);
        }

        protected virtual void OnYandexDataLoaded()
        {
            Initialize();
        }
    }
}