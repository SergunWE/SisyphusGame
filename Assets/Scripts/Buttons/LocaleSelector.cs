﻿using System;
using System.Collections;
using System.Threading.Tasks;
using SDKNewRealization;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace Buttons
{
    public class LocaleSelector : MonoBehaviourInitializable
    {
        [SerializeField] private Button button;
        [SerializeField] private Image imageButton;
        [SerializeField] private Sprite waitSprite;

        protected override void OnEnable()
        {
            base.OnEnable();
            button.onClick.AddListener(ChangeLanguage);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            button.onClick.RemoveListener(ChangeLanguage);
        }

        protected override void Initialize()
        {
            StartCoroutine(LoadLanguageCoroutine());
        }

        private void ChangeLanguage()
        {
            imageButton.sprite = waitSprite;

            int currentLanguageIndex =
                LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
            Locale locale;
            if (currentLanguageIndex == -1 ||
                currentLanguageIndex + 1 >= LocalizationSettings.AvailableLocales.Locales.Count)
            {
                locale = LocalizationSettings.AvailableLocales.Locales[0];
            }
            else
            {
                locale = LocalizationSettings.AvailableLocales.Locales[currentLanguageIndex + 1];
            }

            LocalizationSettings.SelectedLocale = locale;
            SDKManager.Instance.SaveData.CurrentData.ManualLanguage = locale.Identifier.Code;
            SDKManager.Instance.SaveData.Save();
        }

        private IEnumerator LoadLanguageCoroutine()
        {
            while (true)
            {
                if (LocalizationSettings.InitializationOperation.IsDone)
                {
                    break;
                }

                yield return null;
            }
            Locale locale;
            if (string.IsNullOrEmpty(SDKManager.Instance.SaveData.CurrentData.ManualLanguage))
            {
                string localeCode = SDKManager.Instance.PlatformData.LanguageCode;
                locale = LocalizationSettings.AvailableLocales.Locales.Find(x =>
                    x.Identifier.Code == localeCode);
                if (locale == null)
                {
                    locale = LocalizationSettings.SelectedLocale;
                }
            }
            else
            {
                locale = LocalizationSettings.AvailableLocales.Locales.Find(x =>
                    x.Identifier.Code.Contains(SDKManager.Instance.SaveData.CurrentData.ManualLanguage));
                LocalizationSettings.SelectedLocale = locale;
            }

            LocalizationSettings.SelectedLocale = locale;
            SDKManager.Instance.SaveData.CurrentData.ManualLanguage = locale.Identifier.Code;
        }
    }
}