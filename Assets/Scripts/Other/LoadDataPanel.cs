using System.Collections;
using SDKNewRealization;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class LoadDataPanel : MonoBehaviourInitializable
    {
        [SerializeField] private int maxTime;
        
        protected override void Initialize()
        {
            StopAllCoroutines();
            gameObject.SetActive(!SDKManager.Instance.SaveData.IsDataLoaded);
            if (!SDKManager.Instance.SaveData.IsDataLoaded)
            {
                StartCoroutine(WaitCoroutine());
            }
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(maxTime);
            gameObject.SetActive(false);
        }
    }
}