using System;
using SDKNewRealization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class SkillLevel : MonoBehaviourInitializable
    {
        [SerializeField] private Skill skill;
        [SerializeField] private int startCost;
        [SerializeField] private int offsetCost;
        [SerializeField] private Button button;

        [SerializeField, Space] private GameObject costView;
        [SerializeField] private GameObject adView;

        [SerializeField, Space] private TMP_Text textLevel;
        [SerializeField] private TMP_Text textCost;

        private int _cost;
        private bool _useAd;

        protected override void OnEnable()
        {
            base.OnEnable();
            ShopManager.Instance.CoinCountUpdate += TryInitialize;
            SDKManager.Instance.Ads.OnAdOpened += OnAdOpened;
            SDKManager.Instance.Ads.OnAdRewarded += OnAdRewarded;
            SDKManager.Instance.Ads.OnAdClosed += OnAdClosed;
            SDKManager.Instance.Ads.OnAdError += OnAdClosed;
            button.onClick.AddListener(BuySkill);
            TryInitialize();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ShopManager.Instance.CoinCountUpdate -= TryInitialize;
            SDKManager.Instance.Ads.OnAdOpened -= OnAdOpened;
            SDKManager.Instance.Ads.OnAdRewarded -= OnAdRewarded;
            SDKManager.Instance.Ads.OnAdClosed -= OnAdClosed;
            SDKManager.Instance.Ads.OnAdError -= OnAdClosed;
            button.onClick.RemoveListener(BuySkill);
        }
        
        private void OnAdClosed()
        {
            switch (skill)
            {
                case Skill.Speed:
                    AdsShopManager.Instance.GetSpeed(2);
                    break;
                case Skill.Jump:
                    AdsShopManager.Instance.GetJump(2);
                    break;
                case Skill.Power:
                    AdsShopManager.Instance.GetPower(2);
                    break;
                default:
                    break;
            }
        }

        private void OnAdRewarded()
        {
            switch (skill)
            {
                case Skill.Speed:
                    AdsShopManager.Instance.GetSpeed(1);
                    break;
                case Skill.Jump:
                    AdsShopManager.Instance.GetJump(1);
                    break;
                case Skill.Power:
                    AdsShopManager.Instance.GetPower(1);
                    break;
                default:
                    break;
            }
        }

        private void OnAdOpened()
        {
            switch (skill)
            {
                case Skill.Speed:
                    AdsShopManager.Instance.GetSpeed(0);
                    break;
                case Skill.Jump:
                    AdsShopManager.Instance.GetJump(0);
                    break;
                case Skill.Power:
                    AdsShopManager.Instance.GetPower(0);
                    break;
                default:
                    break;
            }
        }

        protected override void Initialize()
        {
            int level = skill switch
            {
                Skill.Speed => SDKManager.Instance.SaveData.CurrentData.SpeedLevel,
                Skill.Jump => SDKManager.Instance.SaveData.CurrentData.GravityLevel,
                Skill.Power => SDKManager.Instance.SaveData.CurrentData.ClickPowerLevel,
                _ => throw new ArgumentOutOfRangeException()
            };
            _cost = startCost + offsetCost * level;
            _useAd = SDKManager.Instance.SaveData.CurrentData.Coins < _cost;
            costView.SetActive(!_useAd);
            adView.SetActive(_useAd);
            textLevel.text = level.ToString();
            textCost.text = _cost.ToString();
        }

        private void BuySkill()
        {
            if (!_useAd)
            {
                ShopManager.Instance.BuySkill(skill, _cost);
            }
            else
            {
                string skillMethodName = skill switch
                {
                    Skill.Speed => nameof(AdsShopManager.GetSpeed),
                    Skill.Jump => nameof(AdsShopManager.GetJump),
                    Skill.Power => nameof(AdsShopManager.GetPower),
                    _ => throw new ArgumentOutOfRangeException()
                };

                SDKManager.Instance.Ads.ShowFullscreenAd();
                //YandexGamesManager.ShowRewardedAdv(AdsShopManager.Instance.gameObject, skillMethodName);
            }
        }
    }
}