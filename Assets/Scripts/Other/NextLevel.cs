using UnityEngine;
using UnityEngine.SceneManagement;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class NextLevel : MonoBehaviour
    {
        public void GoToNext()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber++;
        }

        public void DebugLoadNextLevel()
        {
            SceneManager.LoadSceneAsync(1);
            LocalYandexData.Instance.SaveData();
        }
    }
}