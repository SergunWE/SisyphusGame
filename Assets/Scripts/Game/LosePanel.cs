using System;
using SDKNewRealization;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using YandexSDK.Scripts;
using Random = System.Random;

namespace Game
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private LocalizedString fallPlayerLocalizedString;
        [SerializeField, Space] private GameObject moneyBackButton;
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private Animation panelAnimation;
        [SerializeField] private int startCost;
        [SerializeField] private int offsetCost;

        private int _currentCost;

        private void Awake()
        {
            _currentCost = startCost;
        }

        private void OnEnable()
        {
            moneyBackButton.SetActive(SDKManager.Instance.SaveData.CurrentData.Coins >= _currentCost);
            moneyText.text = _currentCost.ToString();

            text.text = fallPlayerLocalizedString.GetLocalizedString();

            panelAnimation.Play();
        }

        public void BuyContinue()
        {
            if (SDKManager.Instance.SaveData.CurrentData.Coins < _currentCost) return;
            ShopManager.Instance.ChangeCoins(-_currentCost);
            _currentCost += offsetCost;
            GameEvents.Instance.ContinueGame();
            gameObject.SetActive(false);
        }
    }
}