using System.Collections.Generic;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace Buttons
{
    public class SoundButton: MonoBehaviourInitializable
    {
        [SerializeField] private Button button;
        [SerializeField] private Image imageButton;
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;

        [SerializeField, Space] private List<AudioSource> soundSources;
        
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

        public override void Initialize()
        {
            imageButton.sprite = LocalYandexData.Instance.SaveInfo.SoundOn ? onSprite : offSprite;

            foreach (var audioSource in soundSources)
            {
                audioSource.mute = !LocalYandexData.Instance.SaveInfo.SoundOn;
            }
        }

        private void ChangeState()
        {
            LocalYandexData.Instance.SaveInfo.SoundOn = !LocalYandexData.Instance.SaveInfo.SoundOn;
            Initialize();
        }
    }
}