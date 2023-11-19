using System.Collections;
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
            gameObject.SetActive(!LocalYandexData.Instance.YandexDataLoaded);
            if (!LocalYandexData.Instance.YandexDataLoaded)
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