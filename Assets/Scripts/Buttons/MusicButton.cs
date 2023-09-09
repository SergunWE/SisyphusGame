using System;
using System.Collections.Generic;
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
            imageButton.sprite = LocalYandexData.Instance.SaveInfo.MusicOn ? onSprite : offSprite;

            foreach (var audioSource in musicSources)
            {
                audioSource.mute = !LocalYandexData.Instance.SaveInfo.MusicOn;
            }
        }

        private void ChangeState()
        {
            LocalYandexData.Instance.SaveInfo.MusicOn = !LocalYandexData.Instance.SaveInfo.MusicOn;
            LocalYandexData.Instance.SaveData();
            TryInitialize();
        }
    }
}