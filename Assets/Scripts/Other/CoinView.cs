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
            ShopManager.Instance.CoinCountUpdate += Initialize;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ShopManager.Instance.CoinCountUpdate -= Initialize;
        }

        public override void Initialize()
        {
            text.text = LocalYandexData.Instance.SaveInfo.Coins.ToString();
        }
    }
}