using System.Collections;
using System.Threading.Tasks;
using SDKNewRealization;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerDataLoader : MonoBehaviourInitializable
    {
        [SerializeField] private int failedTimeout;
        [SerializeField] private int countTryLoad;

        private int _count;
        
        protected override void Initialize()
        {
            SDKManager.Instance.SaveData.Load();
            //if(LocalYandexData.Instance.YandexDataLoaded) return;
            //YandexGamesManager.LoadPlayerData(gameObject, nameof(OnPlayerDataReceived));
        }

        // public void OnPlayerDataReceived(string json)
        // {
        //     //Debug.Log("OnPlayerDataReceived " + json);
        //     if (string.IsNullOrEmpty(json))
        //     {
        //         Debug.Log("Failed to load player data");
        //         if(_count >= countTryLoad) return;
        //         _count++;
        //         StartCoroutine(RetryCoroutine());
        //     }
        //     else
        //     {
        //         Debug.Log("Data loaded" + json);
        //         LocalYandexData.Instance.SetPlayerData(JsonUtility.FromJson<SaveInfo>(json));
        //     }
        // }

        private IEnumerator RetryCoroutine()
        {
            yield return new WaitForSeconds(failedTimeout);
            Initialize();
        }
    }
}