using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class DebugProgress : MonoBehaviour
    {
        public void Reset()
        {
            LocalYandexData.Instance.ResetProgress();
        }

        public void GetMoney()
        {
            ShopManager.Instance.ChangeCoins(100000);
            LocalYandexData.Instance.SaveData();
        }
    }
}