﻿using System;
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
            button.onClick.AddListener(BuySkill);
            TryInitialize();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ShopManager.Instance.CoinCountUpdate -= TryInitialize;
            button.onClick.RemoveListener(BuySkill);
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

                YandexGamesManager.ShowRewardedAdv(AdsShopManager.Instance.gameObject, skillMethodName);
            }
        }
    }
}