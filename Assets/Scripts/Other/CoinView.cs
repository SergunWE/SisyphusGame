using SDKNewRealization;
using TMPro;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class CoinView : MonoBehaviourInitializable
    {
        [SerializeField] private TMP_Text text;

        protected override void OnEnable()
        {
            base.OnEnable();
            ShopManager.Instance.CoinCountUpdate += TryInitialize;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ShopManager.Instance.CoinCountUpdate -= TryInitialize;
        }

        protected override void Initialize()
        {
            text.text = SDKManager.Instance.SaveData.CurrentData.Coins.ToString();
        }
    }
}