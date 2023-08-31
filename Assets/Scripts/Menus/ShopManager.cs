﻿using System;
using Skins;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class ShopManager
    {
        private static ShopManager _instance;
        public static ShopManager Instance => _instance ??= new ShopManager();

        public event Action SkillPurchaseSuccessful;
        public event Action SkinPurchaseSuccessful;
        public event Action CoinCountUpdate;
        

        private ShopManager()
        {
        }

        public void BuySkill(Skill skill, int cost)
        {
            if (LocalYandexData.Instance.SaveInfo.Coins >= cost)
            {
                LocalYandexData.Instance.SaveInfo.Coins -= cost;
                switch (skill)
                {
                    case Skill.Speed:
                        LocalYandexData.Instance.SaveInfo.SpeedLevel++;
                        break;
                    case Skill.Jump:
                        LocalYandexData.Instance.SaveInfo.GravityLevel++;
                        break;
                    case Skill.Power:
                        LocalYandexData.Instance.SaveInfo.PushingForceLevel++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
                }

                SkillPurchaseSuccessful?.Invoke();
                LocalYandexData.Instance.SaveData();
            }

            CoinCountUpdate?.Invoke();
        }

        public void BuySkin(PlayerSkinSo skin)
        {
            if(skin.LevelCost) return;
            
            if (LocalYandexData.Instance.SaveInfo.Coins >= skin.Cost)
            {
                LocalYandexData.Instance.SaveInfo.Coins -= skin.Cost;
                LocalYandexData.Instance.SaveInfo.PlayerPurchasedSkins.Add(skin.Id);
                SkinPurchaseSuccessful?.Invoke();
            }
            
            CoinCountUpdate?.Invoke();
        }

        public void ChangeCoins(int value)
        {
            LocalYandexData.Instance.SaveInfo.Coins += value;
            CoinCountUpdate?.Invoke();
        }
    }
}