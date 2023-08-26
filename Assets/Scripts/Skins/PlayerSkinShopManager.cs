using System;
using SkibidiRunner.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace Skins
{
    public class PlayerSkinShopManager : MonoBehaviour
    {
        [SerializeField] private PlayerSkinSetter playerSkinSetter;
        [SerializeField, Space] private Button prevSkinButton;
        [SerializeField] private Button buySelectButton;
        [SerializeField] private Button nextSkinButton;
        [SerializeField, Space] private LocalizedString levelLocalizedString;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private GameObject levelCostView;
        [SerializeField] private GameObject moneyCostView;

        [SerializeField, Space] private Image buySelectButtonImage;
        [SerializeField] private Sprite blockedSprite;
        [SerializeField] private Sprite canBuySprite;
        [SerializeField] private Sprite boughtSprite;
        [SerializeField] private Sprite selectedSprite;

        private int _currentSkinIndex;
        private SkinState _skinState;

        private void OnEnable()
        {
            _currentSkinIndex = LocalYandexData.Instance.SaveInfo.PlayerSkinId;
            prevSkinButton.onClick.AddListener(PrevSkin);
            nextSkinButton.onClick.AddListener(NextSkin);
            buySelectButton.onClick.AddListener(OnBuySelectClicked);

            ShowSkin(_currentSkinIndex);
        }

        private void OnDisable()
        {
            prevSkinButton.onClick.RemoveListener(PrevSkin);
            nextSkinButton.onClick.RemoveListener(NextSkin);
            buySelectButton.onClick.RemoveListener(OnBuySelectClicked);
            playerSkinSetter.SetCurrentSkin();
        }

        private void OnBuySelectClicked()
        {
            if (_skinState == SkinState.Bought)
            {
                SelectSkin();
            }

            if (_skinState == SkinState.CanBuy)
            {
                BuySkin();
            }
        }

        private void SelectSkin()
        {
            var currentSkin = playerSkinSetter.PlayerList[_currentSkinIndex];

            switch (currentSkin.LevelCost)
            {
                case true when LocalYandexData.Instance.SaveInfo.LevelNumber >= currentSkin.Cost:
                    SetSkin(currentSkin);
                    return;
                case false when
                    LocalYandexData.Instance.SaveInfo.PlayerPurchasedSkins.IndexOf(currentSkin.Id) != -1 ||
                    currentSkin.Cost <= 0:
                    SetSkin(currentSkin);
                    return;
            }
        }

        private void BuySkin()
        {
            var currentSkin = playerSkinSetter.PlayerList[_currentSkinIndex];
            ShopManager.Instance.BuySkin(currentSkin);
            ShowSkin(_currentSkinIndex);
        }

        private void SetSkin(PlayerSkinSo skin)
        {
            LocalYandexData.Instance.SaveInfo.PlayerSkinId = skin.Id;
            ShopManager.Instance.AddCoins(0);
            SetBuySelectButtonState();
            SetBuySelectButtonView();
        }

        private void NextSkin()
        {
            ShowSkin(_currentSkinIndex + 1);
        }

        private void PrevSkin()
        {
            ShowSkin(_currentSkinIndex - 1);
        }

        private void ShowSkin(int index)
        {
            prevSkinButton.gameObject.SetActive(index > 0);
            nextSkinButton.gameObject.SetActive(index < playerSkinSetter.PlayerList.Count - 1);

            _currentSkinIndex = index;
            playerSkinSetter.SetSkin(playerSkinSetter.PlayerList[index]);
            SetBuySelectButtonState();
            SetBuySelectButtonView();
        }

        private void SetBuySelectButtonState()
        {
            var currentSkin = playerSkinSetter.PlayerList[_currentSkinIndex];

            if (currentSkin.Id == LocalYandexData.Instance.SaveInfo.PlayerSkinId)
            {
                _skinState = SkinState.Selected;
            }
            else
            {
                if (LocalYandexData.Instance.SaveInfo.PlayerPurchasedSkins.IndexOf(currentSkin.Id) != -1)
                {
                    _skinState = SkinState.Bought;
                }
                else
                {
                    if (currentSkin.LevelCost)
                    {
                        _skinState = LocalYandexData.Instance.SaveInfo.LevelNumber >= currentSkin.Cost
                            ? SkinState.Bought
                            : SkinState.Blocked;
                    }
                    else
                    {
                        _skinState = SkinState.CanBuy;
                    }
                }
            }
        }

        private void SetBuySelectButtonView()
        {
            levelCostView.SetActive(_skinState == SkinState.Blocked);
            moneyCostView.SetActive(_skinState == SkinState.CanBuy);

            buySelectButtonImage.sprite = _skinState switch
            {
                SkinState.Blocked => blockedSprite,
                SkinState.CanBuy => canBuySprite,
                SkinState.Bought => boughtSprite,
                SkinState.Selected => selectedSprite,
                _ => throw new ArgumentOutOfRangeException()
            };

            levelText.text =
                levelLocalizedString.GetLocalizedString(playerSkinSetter.PlayerList[_currentSkinIndex].Cost + 1);
            moneyText.text = playerSkinSetter.PlayerList[_currentSkinIndex].Cost.ToString();
        }
    }
}