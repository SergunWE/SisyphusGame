using System;
using SDKNewRealization;
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
                    if (SDKManager.Instance.SaveData.IsDataLoaded)
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
            SDKManager.Instance.SaveData.DataLoaded += TryInitialize;
        }

        protected virtual void OnDisable()
        {
            SDKManager.Instance.SaveData.DataLoaded -= TryInitialize;
        }

        protected virtual void OnYandexDataLoaded()
        {
            Initialize();
        }
    }
}