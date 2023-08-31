using UnityEngine;
using YandexSDK.Scripts;
using DeviceType = YandexSDK.Scripts.DeviceType;

namespace SkibidiRunner.Managers
{
    public class MobileInput : MonoBehaviourInitializable
    {
        [SerializeField] private GameObject mobileInput;
        
        protected override void Initialize()
        {
            mobileInput.SetActive(YandexGamesManager.GetDeviceType() != DeviceType.Desktop);
        }
    }
}