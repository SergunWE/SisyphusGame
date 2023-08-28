using System.Threading.Tasks;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerDataLoader : MonoBehaviourInitializable
    {
        private TaskCompletionSource<bool> _task;
        
        public override void Initialize()
        {
            if(LocalYandexData.Instance.YandexDataLoaded) return;
            _task = new TaskCompletionSource<bool>();
            YandexGamesManager.LoadPlayerData(gameObject.name, nameof(OnPlayerDataReceived));
            _task.Task.Wait(5000);
        }

        public void OnPlayerDataReceived(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                Debug.Log("Failed to load player data");
                _task?.SetResult(false);
            }
            else
            {
                LocalYandexData.Instance.SetPlayerData(JsonUtility.FromJson<SaveInfo>(json));
                _task?.SetResult(true);
            }
        }
    }
}