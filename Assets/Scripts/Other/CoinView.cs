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
            Debug.Log("COIN ENABLE");
            base.OnEnable();
            ShopManager.Instance.CoinCountUpdate += TryInitialize;
        }

        protected override void OnDisable()
        {
            Debug.Log("COIN DISABLE");
            base.OnDisable();
            ShopManager.Instance.CoinCountUpdate -= TryInitialize;
        }

        protected override void Initialize()
        {
            Debug.Log("COIN Initialize " + LocalYandexData.Instance.SaveInfo.Coins);
            text.text = LocalYandexData.Instance.SaveInfo.Coins.ToString();
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if(!hasFocus) return;
            Initialize();
        }
    }
}