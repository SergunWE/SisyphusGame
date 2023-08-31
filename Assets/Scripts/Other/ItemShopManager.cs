using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class ItemShopManager : MonoBehaviour
    {
        public void BuyCoins()
        {
            ShopManager.Instance.ChangeCoins(400);
        }

        public void SkipLevel()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber++;
            LocalYandexData.Instance.SaveData();
            LocalYandexData.Instance.ForcedUpdate();
        }

        public void ResetLevel()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber = 0;
            LocalYandexData.Instance.SaveData();
            LocalYandexData.Instance.ForcedUpdate();
        }
    }
}