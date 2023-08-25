using System;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using YandexSDK.Scripts;

namespace Menus
{
    public class GiftTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;

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
                timerText.text = "Доступно";
            }
        }
    }
}