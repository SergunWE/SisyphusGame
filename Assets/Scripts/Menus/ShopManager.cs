using System;
using SDKNewRealization;
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
        public event Action CoinAdded;
        

        private ShopManager()
        {
        }

        public void BuySkill(Skill skill, int cost)
        {
            if (SDKManager.Instance.SaveData.CurrentData.Coins >= cost)
            {
                SDKManager.Instance.SaveData.CurrentData.Coins -= cost;
                switch (skill)
                {
                    case Skill.Speed:
                        SDKManager.Instance.SaveData.CurrentData.SpeedLevel++;
                        break;
                    case Skill.Jump:
                        SDKManager.Instance.SaveData.CurrentData.GravityLevel++;
                        break;
                    case Skill.Power:
                        SDKManager.Instance.SaveData.CurrentData.ClickPowerLevel++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
                }

                SkillPurchaseSuccessful?.Invoke();
            }

            CoinCountUpdate?.Invoke();
            SDKManager.Instance.SaveData.Save();
        }

        public void BuySkin(PlayerSkinSo skin)
        {
            if(skin.LevelCost) return;
            
            if (SDKManager.Instance.SaveData.CurrentData.Coins >= skin.Cost)
            {
                SDKManager.Instance.SaveData.CurrentData.Coins -= skin.Cost;
                SDKManager.Instance.SaveData.CurrentData.PlayerPurchasedSkins.Add(skin.Id);
                SkinPurchaseSuccessful?.Invoke();
            }
            
            CoinCountUpdate?.Invoke();
            SDKManager.Instance.SaveData.Save();
        }

        public void ChangeCoins(int value)
        {
            SDKManager.Instance.SaveData.CurrentData.Coins += value;
            CoinCountUpdate?.Invoke();
            if (value > 0)
            {
                CoinAdded?.Invoke();
            }
            SDKManager.Instance.SaveData.Save();
        }
    }
}