using System;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using YandexSDK.Scripts;

namespace Menus
{
    public class GiftManager : MonoBehaviourInitializable
    {
        [SerializeField] private int giftStartCount = 50;
        [SerializeField] private int giftLevelOffset = 50;
        [SerializeField] private GameObject giftPanel;
        [SerializeField] private Animation giftAnimation;
        [SerializeField] private TMP_Text rewardCountText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private LocalizedString localizedString;

        private string _localString;
        
        private void FixedUpdate()
        {
            var time = TimeSpan.FromDays(1) -
                       TimeSpan.FromTicks(DateTime.UtcNow.Ticks -
                                          LocalYandexData.Instance.SaveInfo.DailyRewardTimeTicks);
            if (time > TimeSpan.Zero)
            {
                timerText.text = time.ToString(time.Hours > 0 ? @"h\:mm\:ss" : @"m\:ss");
            }
            else
            {
                timerText.text = _localString;
            }
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            localizedString.StringChanged += LocalizedStringOnStringChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            localizedString.StringChanged -= LocalizedStringOnStringChanged;
        }
        
        public void GetGift()
        {
            var time = TimeSpan.FromDays(1) -
                       TimeSpan.FromTicks(DateTime.UtcNow.Ticks -
                                          LocalYandexData.Instance.SaveInfo.DailyRewardTimeTicks);

            if (time <= TimeSpan.Zero)
            {
                int reward = giftStartCount + giftLevelOffset * LocalYandexData.Instance.SaveInfo.DailyRewardLevel;
                rewardCountText.text = reward.ToString();
                
                LocalYandexData.Instance.SaveInfo.DailyRewardLevel++;
                LocalYandexData.Instance.SaveInfo.DailyRewardTimeTicks = DateTime.UtcNow.Ticks;
                ShopManager.Instance.ChangeCoins(reward);
                
                giftPanel.SetActive(true);
                giftAnimation.Play();
            }
        }

        protected override void Initialize()
        {
            _localString = localizedString.GetLocalizedString();
        }
        
        private void LocalizedStringOnStringChanged(string value)
        {
            _localString = value;
        }
    }
}