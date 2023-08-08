
    using SkibidiRunner.Managers;
    using UnityEngine;
    using YandexSDK.Scripts;

    public class DebugSaveInfoSetter : MonoBehaviourInitializable
    {
        [SerializeField] private SaveInfo saveInfo;
        
        public override void Initialize()
        {
            saveInfo.LastSaveTimeTicks = 1;
            LocalYandexData.Instance.DebugSetPlayerData(saveInfo);
        }
    }
