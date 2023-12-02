using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDKNewRealization
{
    public class SDKManager : MonoBehaviour
    {
#if UNITY_ANDROID
        [SerializeField] private string androidSaveKey;
        [SerializeField] private string adUnitId = "demo-rewarded-yandex"; // замените на "R-M-XXXXXX-Y"
#endif

        public static SDKManager Instance { get; private set; }

        public ISaveData SaveData { get; private set; }
        public IAds Ads { get; private set; }
        public IPlatformData PlatformData { get; private set; }

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SaveData = GetPlatformSpecificSaveData();
            Ads = GetPlatformSpecificAds();
            PlatformData = GetPlatformSpecificData();
            SceneManager.LoadSceneAsync(1);
        }

        private ISaveData GetPlatformSpecificSaveData()
        {
#if UNITY_ANDROID
            return new AndroidSaveData(androidSaveKey);
#endif
            return null;
        }

        private IAds GetPlatformSpecificAds()
        {
#if UNITY_ANDROID
            return new AndroidYandexAds(adUnitId);
#else
            return null;
#endif
        }

        private static IPlatformData GetPlatformSpecificData()
        {
#if UNITY_ANDROID
            return new AndroidPlatformData();
#else
            return null;
#endif
        }
    }
}