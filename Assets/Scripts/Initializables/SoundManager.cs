using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SoundManager : MonoBehaviourInitializable
    {
        [SerializeField] private AudioSource audioSource;

        public override void Initialize()
        {
            audioSource.mute = !LocalYandexData.Instance.SaveInfo.SoundOn;
        }

        public void PlaySound(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}