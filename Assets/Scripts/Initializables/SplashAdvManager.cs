﻿using System;
using UnityEngine;
using UnityEngine.Events;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SplashAdvManager : MonoBehaviour
    {
        [SerializeField] private bool showStartup;

        [SerializeField] public UnityEvent advStarted;
        [SerializeField] public UnityEvent advEnded;

        private void Start()
        {
            if (showStartup)
            {
                ShowAdv();
            }
        }

        public bool ShowAdv()
        {
            YandexGamesManager.ShowSplashAdv(gameObject.name, nameof(AdvCallback));
            return true;
        }

        public void AdvCallback(int result)
        {
            switch (result)
            {
                case 0:
                    advStarted?.Invoke();
                    break;
                case 1:
                    advEnded?.Invoke();
                    break;
            }
        }
    }
}