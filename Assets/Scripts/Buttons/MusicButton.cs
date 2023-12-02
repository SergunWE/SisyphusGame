using System;
using System.Collections.Generic;
using SDKNewRealization;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace Buttons
{
    public class MusicButton : MonoBehaviourInitializable
    {
        [SerializeField] private Button button;
        [SerializeField] private Image imageButton;
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;

        [SerializeField, Space] private List<AudioSource> musicSources;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            button.onClick.AddListener(ChangeState);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            button.onClick.RemoveListener(ChangeState);
        }

        protected override void Initialize()
        {
            imageButton.sprite = SDKManager.Instance.SaveData.CurrentData.MusicOn ? onSprite : offSprite;

            foreach (var audioSource in musicSources)
            {
                audioSource.mute = !SDKManager.Instance.SaveData.CurrentData.MusicOn;
            }
        }

        private void ChangeState()
        {
            SDKManager.Instance.SaveData.CurrentData.MusicOn = !SDKManager.Instance.SaveData.CurrentData.MusicOn;
            SDKManager.Instance.SaveData.Save();
            TryInitialize();
        }
    }
}