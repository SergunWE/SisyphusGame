using System;

namespace SDKNewRealization
{
    public interface IAds
    {
        event Action OnAdOpened;
        event Action OnAdRewarded;
        event Action OnAdClosed;
        event Action OnAdError;
        
        void ShowFullscreenAd();
        void ShowRewardedAd();
    }
}