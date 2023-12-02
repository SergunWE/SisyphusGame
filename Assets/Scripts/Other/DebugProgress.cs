using SDKNewRealization;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class DebugProgress : MonoBehaviour
    {
        public void Reset()
        {
            SDKManager.Instance.SaveData.DebugSetData(new StoredData());
        }

        public void GetMoney()
        {
            ShopManager.Instance.ChangeCoins(100000);
            SDKManager.Instance.SaveData.Save();
        }
    }
}