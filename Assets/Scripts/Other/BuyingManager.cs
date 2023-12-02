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

        protected void OnDisable()
        {
            ShopManager.Instance.CoinCountUpdate -= Init;
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
                YandexGamesManager.ShowRewardedAdv(gameObject, nameof(BuyForAds));
            }
        }

        public void BuyForAds(int result)
        {
            switch (result)
            {
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    buyItem?.Invoke();
                    ShopManager.Instance.ChangeCoins(0);
                    break;
                case 2:
                    PauseManager.Instance.ResumeGame();
                    break;
            }
        }
    }
}