using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class DebugReset : MonoBehaviour
    {
        public void Reset()
        {
            LocalYandexData.Instance.ResetProgress();
        }
    }
}