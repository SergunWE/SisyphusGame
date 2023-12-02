using System;

namespace SDKNewRealization
{
    public class AndroidAds : IAds
    {
        public event Action OnAdOpened;
        public event Action OnAdRewarded;
        public event Action OnAdClosed;
        public event Action OnAdError;

        public void ShowFullscreenAd()
        {
            
        }

        public void ShowRewardedAd()
        {
            
        }
    }
}