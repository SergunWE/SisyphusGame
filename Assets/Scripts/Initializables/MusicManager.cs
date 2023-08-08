using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class MusicManager: MonoBehaviourInitializable
    {
        [SerializeField] private AudioSource musicSource;
        
        public override void Initialize()
        {
            musicSource.mute = !LocalYandexData.Instance.SaveInfo.MusicOn;
        }
    }
}