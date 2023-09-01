using System;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using YandexSDK.Scripts;
using DeviceType = YandexSDK.Scripts.DeviceType;

namespace Game
{
    public class Training : MonoBehaviourInitializable
    {
        [SerializeField] private TMP_Text firstText;
        [SerializeField] private TMP_Text secondText;
        [SerializeField] private TMP_Text stoneText;

        [SerializeField, Space] private LocalizedString mobileFirstLocalizedString;
        [SerializeField] private LocalizedString mobileSecondLocalizedString;
        
        [SerializeField, Space] private LocalizedString pcFirstLocalizedString;
        [SerializeField] private LocalizedString pcSecondLocalizedString;
        
        [SerializeField, Space] private LocalizedString stoneFirstLocalizedString;
        [SerializeField] private LocalizedString stoneSecondLocalizedString;
        
        [SerializeField, Space] private LocalizedString obstacleLocalizedString;

        private void Set()
        {
            bool desktop = YandexGamesManager.GetDeviceType() == DeviceType.Desktop;
            
            switch (LocalYandexData.Instance.SaveInfo.LevelNumber)
            {
                case 0:
                    firstText.text = desktop
                        ? pcFirstLocalizedString.GetLocalizedString()
                        : mobileFirstLocalizedString.GetLocalizedString();
                    secondText.text = desktop
                        ? pcSecondLocalizedString.GetLocalizedString()
                        : mobileSecondLocalizedString.GetLocalizedString();
                    stoneText.text = stoneFirstLocalizedString.GetLocalizedString();
                    break;
                case 3:
                    firstText.text = obstacleLocalizedString.GetLocalizedString();
                    secondText.gameObject.SetActive(false);
                    stoneText.text = stoneSecondLocalizedString.GetLocalizedString();
                    break;
                default:
                    firstText.gameObject.SetActive(false);
                    secondText.gameObject.SetActive(false);
                    stoneText.gameObject.SetActive(false);
                    break;
            }
        }

        protected override void Initialize()
        {
            Set();
        }
    }
}