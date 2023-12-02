using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

namespace SDKNewRealization
{
    public class YandexMobileAdsRewarded : MonoBehaviour
    {
        public static YandexMobileAdsRewarded Instance { get; private set; }
        
        private RewardedAdLoader _rewardedAdLoader;
        private RewardedAd _rewardedAd;

        private void Awake()
        {
            if(Instance != null) return;
            Instance = this;
            SetupLoader();
            RequestRewardedAd();
            DontDestroyOnLoad(gameObject);
        }

        private void SetupLoader()
        {
            _rewardedAdLoader = new RewardedAdLoader();
            _rewardedAdLoader.OnAdLoaded += HandleAdLoaded;
            _rewardedAdLoader.OnAdFailedToLoad += HandleAdFailedToLoad;
        }

        private void RequestRewardedAd()
        {
            string adUnitId = "demo-rewarded-yandex"; // замените на "R-M-XXXXXX-Y"
            AdRequestConfiguration adRequestConfiguration = new AdRequestConfiguration.Builder(adUnitId).Build();
            _rewardedAdLoader.LoadAd(adRequestConfiguration);
        }

        public void ShowRewardedAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Show();
            }
        }

        public void HandleAdLoaded(object sender, RewardedAdLoadedEventArgs args)
        {
            // The ad was loaded successfully. Now you can handle it.
            _rewardedAd = args.RewardedAd;

            // Add events handlers for ad actions
            _rewardedAd.OnAdClicked += HandleAdClicked;
            _rewardedAd.OnAdShown += HandleAdShown;
            _rewardedAd.OnAdFailedToShow += HandleAdFailedToShow;
            _rewardedAd.OnAdImpression += HandleImpression;
            _rewardedAd.OnAdDismissed += HandleAdDismissed;
            _rewardedAd.OnRewarded += HandleRewarded;
        }

        public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            // Ad {args.AdUnitId} failed for to load with {args.Message}
            // Attempting to load a new ad from the OnAdFailedToLoad event is strongly discouraged.
        }

        public void HandleAdDismissed(object sender, EventArgs args)
        {
            // Called when an ad is dismissed.

            // Clear resources after an ad dismissed.
            DestroyRewardedAd();

            // Now you can preload the next rewarded ad.
            RequestRewardedAd();
        }

        public void HandleAdFailedToShow(object sender, AdFailureEventArgs args)
        {
            // Called when rewarded ad failed to show.

            // Clear resources after an ad dismissed.
            DestroyRewardedAd();

            // Now you can preload the next rewarded ad.
            RequestRewardedAd();
        }

        public void HandleAdClicked(object sender, EventArgs args)
        {
            // Called when a click is recorded for an ad.
        }

        public void HandleAdShown(object sender, EventArgs args)
        {
            // Called when an ad is shown.
        }

        public void HandleImpression(object sender, ImpressionData impressionData)
        {
            // Called when an impression is recorded for an ad.
        }

        public void HandleRewarded(object sender, Reward args)
        {
            // Called when the user can be rewarded with {args.type} and {args.amount}.
        }

        public void DestroyRewardedAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }
        }
    }
}