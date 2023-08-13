﻿using UnityEngine;
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
                        (int)Mathf.Round(winGameCoinArithmeticOffset * LocalYandexData.Instance.SaveInfo.LevelNumber) +
                        (int)Mathf.Round(winGameCoinCount * LocalYandexData.Instance.SaveInfo.LevelNumber * winGameCoinGeometricOffset);
            Debug.Log("Level award count: " + award);
            LocalYandexData.Instance.SaveInfo.Coins += award;
        }
        
        
        public void GetBonusReward(int multiplier)
        {
            int bonusAward = GameInfo.Instance.CoinCount * multiplier;
            Debug.Log("Bonus award count: " + bonusAward);
            LocalYandexData.Instance.SaveInfo.Coins += bonusAward;
        }
    }
}