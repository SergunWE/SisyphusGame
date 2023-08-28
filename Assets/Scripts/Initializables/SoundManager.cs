using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SoundManager : MonoBehaviourInitializable
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private AudioSource audioSource;
        
        protected override void Initialize()
        {
            Instance = this;
            audioSource.mute = !LocalYandexData.Instance.SaveInfo.SoundOn;
        }

        public void PlaySound(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}