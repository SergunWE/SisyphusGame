using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SoundManager : MonoBehaviourInitializable
    {
        private static SoundManager _instance;
        public static SoundManager Instance => _instance;
        
        [SerializeField] private AudioSource audioSource;
        
        public override void Initialize()
        {
            _instance = this;
            audioSource.mute = !LocalYandexData.Instance.SaveInfo.SoundOn;
        }

        public void PlaySound(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}