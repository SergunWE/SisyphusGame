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

        public override async void Initialize()
        {
            await LocalizationSettings.InitializationOperation.Task;

            Locale locale;
            if (string.IsNullOrEmpty(LocalYandexData.Instance.SaveInfo.ManualLanguage))
            {
                string localeCode = YandexGamesManager.GetLanguageString();
                locale = LocalizationSettings.AvailableLocales.Locales.Find(x =>
                    x.Identifier.Code == localeCode);
                if (locale == null)
                {
                    locale = LocalizationSettings.AvailableLocales.Locales[0];
                }
            }
            else
            {
                locale = LocalizationSettings.AvailableLocales.Locales.Find(x =>
                    x.Identifier.Code.Contains(LocalYandexData.Instance.SaveInfo.ManualLanguage));
                LocalizationSettings.SelectedLocale = locale;
            }

            LocalizationSettings.SelectedLocale = locale;
            LocalYandexData.Instance.SaveInfo.ManualLanguage = locale.Identifier.Code;
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
            LocalYandexData.Instance.SaveInfo.ManualLanguage = locale.Identifier.Code;
        }
    }
}