using SDKNewRealization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class BuyingManager : MonoBehaviour
    {
        [SerializeField] private int cost;
        [SerializeField] private bool onlyForAds;
        [SerializeField] private Button button;
        
        [SerializeField, Space] private GameObject costView;
        [SerializeField] private GameObject adView;
        [SerializeField] private TMP_Text textCost;

        [SerializeField, Space] private UnityEvent buyItem;
        
        private bool _useAd;
        
        protected void OnEnable()
        {
            ShopManager.Instance.CoinCountUpdate += Init;
            button.onClick.AddListener(Buy);
            Init();
        }

        private void OnAdClosed()
        {
            PauseManager.Instance.ResumeGame();
            SDKManager.Instance.Ads.OnAdOpened -= OnAdOpened;
            SDKManager.Instance.Ads.OnAdRewarded -= OnAdRewarded;
            SDKManager.Instance.Ads.OnAdClosed -= OnAdClosed;
            SDKManager.Instance.Ads.OnAdError -= OnAdClosed;
        }

        private void OnAdRewarded()
        {
            buyItem?.Invoke();
            ShopManager.Instance.ChangeCoins(0);
        }

        private void OnAdOpened()
        {
            PauseManager.Instance.PauseGame();
        }

        protected void OnDisable()
        {
            ShopManager.Instance.CoinCountUpdate -= Init;
            SDKManager.Instance.Ads.OnAdOpened -= OnAdOpened;
            SDKManager.Instance.Ads.OnAdRewarded -= OnAdRewarded;
            SDKManager.Instance.Ads.OnAdClosed -= OnAdClosed;
            SDKManager.Instance.Ads.OnAdError -= OnAdClosed;
            button.onClick.RemoveListener(Buy);
        }

        private void Init()
        {
            _useAd = SDKManager.Instance.SaveData.CurrentData.Coins < cost || onlyForAds;
            costView.SetActive(!_useAd);
            adView.SetActive(_useAd);
            textCost.text = cost.ToString();
        }

        private void Buy()
        {
            if (!_useAd)
            {
                buyItem?.Invoke();
                ShopManager.Instance.ChangeCoins(-cost);
            }
            else
            {
                SDKManager.Instance.Ads.OnAdOpened += OnAdOpened;
                SDKManager.Instance.Ads.OnAdRewarded += OnAdRewarded;
                SDKManager.Instance.Ads.OnAdClosed += OnAdClosed;
                SDKManager.Instance.Ads.OnAdError += OnAdClosed;
                SDKManager.Instance.Ads.ShowRewardedAd();
            }
        }
    }
}