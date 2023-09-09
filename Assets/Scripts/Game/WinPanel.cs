using System;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using Random = System.Random;

namespace Game
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private LocalizedString bestLocalizedString;
        [SerializeField] private TMP_Text bestText;

        [SerializeField, Space] private int minPercent;
        [SerializeField] private int maxPercent;
        
        [SerializeField, Space] private TMP_Text moneyText;
        [SerializeField] private Animation panelAnimation;

        private Random _random;
        
        private void Awake()
        {
            _random = new Random(DateTime.UtcNow.Millisecond);
        }

        private void OnEnable()
        {
            bestText.text = bestLocalizedString.GetLocalizedString(_random.Next(minPercent, maxPercent));
            SetEarnedMoney();
            panelAnimation.Play();
        }

        public void SetEarnedMoney()
        {
            moneyText.text = GameInfo.Instance.CoinCount.ToString();
        }
    }
}