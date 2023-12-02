﻿using SDKNewRealization;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class AwardManager : MonoBehaviour
    {
        [SerializeField] private int winGameCoinCount;
        [SerializeField] private float winGameCoinArithmeticOffset;
        [SerializeField] private float winGameCoinGeometricOffset;

        public void GetLevelReward()
        {
            int award = winGameCoinCount +
                        (int)Mathf.Round(winGameCoinArithmeticOffset * SDKManager.Instance.SaveData.CurrentData.LevelNumber);
            award += (int)(award * winGameCoinGeometricOffset);
            //Debug.Log("Level award count: " + award);
            GameInfo.Instance.CoinCount += award;
            ShopManager.Instance.ChangeCoins(award);
        }
        
        
        public void GetBonusReward(int multiplier)
        {
            int bonusAward = GameInfo.Instance.CoinCount * multiplier - 1;
            GameInfo.Instance.CoinCount += bonusAward;
            //Debug.Log("Bonus award count: " + bonusAward);
            ShopManager.Instance.ChangeCoins(bonusAward);
        }
    }
}