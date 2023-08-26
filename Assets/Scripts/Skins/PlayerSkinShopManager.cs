using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YandexSDK.Scripts;

namespace Skins
{
    public class PlayerSkinShopManager : MonoBehaviour
    {
        [SerializeField] private PlayerSkinSetter playerSkinSetter;
        [SerializeField, Space] private Button prevSkinButton;
        [SerializeField, Space] private Button nextSkinButton;

        private int _currentSkinIndex;

        private void OnEnable()
        {
            _currentSkinIndex = LocalYandexData.Instance.SaveInfo.PlayerSkinId;
            prevSkinButton.onClick.AddListener(PrevSkin);
            nextSkinButton.onClick.AddListener(NextSkin);

            prevSkinButton.gameObject.SetActive(_currentSkinIndex > 0);
            nextSkinButton.gameObject.SetActive(_currentSkinIndex < playerSkinSetter.PlayerList.Count - 1);
        }

        private void OnDisable()
        {
            prevSkinButton.onClick.RemoveListener(PrevSkin);
            nextSkinButton.onClick.RemoveListener(NextSkin);
            playerSkinSetter.SetCurrentSkin();
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
        }
    }
}