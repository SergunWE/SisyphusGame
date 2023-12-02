using SDKNewRealization;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class MusicManager: MonoBehaviourInitializable
    {
        [SerializeField] private AudioSource musicSource;
        
        protected override void Initialize()
        {
            musicSource.mute = !SDKManager.Instance.SaveData.CurrentData.MusicOn;
        }
    }
}