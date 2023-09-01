using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SplashAdvManager : MonoBehaviour
    {
        [SerializeField] private bool showStartup;
        [SerializeField] private int delaySeconds;

        private static DateTime _adsTime;
        
        private void Start()
        {
            if (showStartup)
            {
                ShowAdv();
            }
        }

        public void ShowAdv()
        {
            if (DateTime.UtcNow - _adsTime > TimeSpan.FromSeconds(delaySeconds))
            {
                YandexGamesManager.ShowSplashAdv(gameObject.name, nameof(AdvCallback));
            }
        }

        public void AdvCallback(int result)
        {
            switch (result)
            {
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    PauseManager.Instance.ResumeGame();
                    _adsTime = DateTime.UtcNow;
                    break;
            }
        }
    }
}