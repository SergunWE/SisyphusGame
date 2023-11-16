using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class ItemShopManager : MonoBehaviour
    {
        [SerializeField] private LevelNumberView levelView;

        public void BuyCoins(int coinsCount = 1000)
        {
            ShopManager.Instance.ChangeCoins(coinsCount);
        }

        public void SkipLevel()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber++;
            levelView.TryInitialize();
        }

        public void ResetLevel()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber = 0;
            levelView.TryInitialize();
        }
    }
}