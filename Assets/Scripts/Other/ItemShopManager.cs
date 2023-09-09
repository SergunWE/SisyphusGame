using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class ItemShopManager : MonoBehaviour
    {
        [SerializeField] private LevelNumberView levelView;
        
        public void BuyCoins()
        {
            ShopManager.Instance.ChangeCoins(400);
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