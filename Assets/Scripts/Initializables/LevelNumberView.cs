using System;
using SDKNewRealization;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class LevelNumberView : MonoBehaviourInitializable
    {
        [SerializeField] private LocalizedString localizedString;
        [SerializeField] private TMP_Text text;

        private int _levelCount;

        protected override void OnEnable()
        {
            base.OnEnable();
            localizedString.StringChanged += LocalizedStringOnStringChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            localizedString.StringChanged -= LocalizedStringOnStringChanged;
        }

        private void LocalizedStringOnStringChanged(string value)
        {
            text.text = value;
        }

        protected override void Initialize()
        {
            localizedString.Arguments = new object[] { _levelCount };
            _levelCount = SDKManager.Instance.SaveData.CurrentData.LevelNumber + 1;
            localizedString.Arguments[0] = _levelCount;
            localizedString.RefreshString();
        }
    }
}