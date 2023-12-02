using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

namespace SDKNewRealization
{
    public class AndroidYandexAds : IAds
    {
        public event Action OnAdOpened;
        public event Action OnAdRewarded;
        public event Action OnAdClosed;
        public event Action OnAdError;
        
        private RewardedAdLoader _rewardedAdLoader;
        private RewardedAd _rewardedAd;

        private readonly string _adUnitId;

        public AndroidYandexAds(string adUnitId)
        {
            _adUnitId = adUnitId;
            SetupLoader();
            RequestRewardedAd();
        }
        
        public void ShowFullscreenAd()
        {
            
        }

        public void ShowRewardedAd()
        {
            _rewardedAd?.Show();
        }
        
        private void SetupLoader()
        {
            _rewardedAdLoader = new RewardedAdLoader();
            _rewardedAdLoader.OnAdLoaded += HandleAdLoaded;
            _rewardedAdLoader.OnAdFailedToLoad += OnAdFailedToLoad;
        }
        
        private void RequestRewardedAd()
        {
            var adRequestConfiguration = new AdRequestConfiguration.Builder(_adUnitId).Build();
            _rewardedAdLoader.LoadAd(adRequestConfiguration);
        }

        private void HandleAdLoaded(object sender, RewardedAdLoadedEventArgs args)
        {
            _rewardedAd = args.RewardedAd;
            
            _rewardedAd.OnAdShown += OnAdShown;
            _rewardedAd.OnAdFailedToShow += OnAdFailedToShow;
            _rewardedAd.OnAdDismissed += OnAdDismissed;
            _rewardedAd.OnRewarded += OnRewarded;
        }

        private void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            Debug.Log($"Ad {args.AdUnitId} failed for to load with {args.Message}");
            OnAdError?.Invoke();
        }

        private void OnAdDismissed(object sender, EventArgs args)
        {
            DestroyRewardedAd();
            RequestRewardedAd();
            OnAdClosed?.Invoke();
        }

        private void OnAdFailedToShow(object sender, AdFailureEventArgs args)
        {
            DestroyRewardedAd();
            RequestRewardedAd();
        }

        private void OnAdShown(object sender, EventArgs args)
        {
            OnAdOpened?.Invoke();
        }

        private void OnRewarded(object sender, Reward args)
        {
            OnAdRewarded?.Invoke();
        }

        private void DestroyRewardedAd()
        {
            if (_rewardedAd == null) return;
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }
    }
}