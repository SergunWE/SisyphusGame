using SDKNewRealization;
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
            SDKManager.Instance.SaveData.CurrentData.LevelNumber++;
            levelView.TryInitialize();
        }

        public void ResetLevel()
        {
            SDKManager.Instance.SaveData.CurrentData.LevelNumber = 0;
            levelView.TryInitialize();
        }
    }
}