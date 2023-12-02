using SDKNewRealization;
using UnityEngine;
using UnityEngine.SceneManagement;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class NextLevel : MonoBehaviour
    {
        public void GoToNext()
        {
            SDKManager.Instance.SaveData.CurrentData.LevelNumber++;
            //YandexGamesManager.SetToLeaderboard(SDKManager.Instance.SaveData.CurrentData.LevelNumber);
            SDKManager.Instance.SaveData.Save();
        }

        public void GoToMainMenu()
        {
            SDKManager.Instance.SaveData.Save();
            Cursor.lockState = CursorLockMode.None;
            SDKManager.Instance.Ads.ShowFullscreenAd();
            SceneManager.LoadSceneAsync(1);
        }

        public void ReloadGame()
        {
            SDKManager.Instance.SaveData.Save();
            Cursor.lockState = CursorLockMode.None;
            SDKManager.Instance.Ads.ShowFullscreenAd();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}