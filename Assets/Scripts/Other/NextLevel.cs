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
            YandexGamesManager.SetToLeaderboard(SDKManager.Instance.SaveData.CurrentData.LevelNumber);
            SDKManager.Instance.SaveData.Save();
        }

        public void GoToMainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            SDKManager.Instance.SaveData.Save();
            SplashAdvManager.Instance.ShowAdv();
            SceneManager.LoadSceneAsync(0);
        }

        public void ReloadGame()
        {
            Cursor.lockState = CursorLockMode.None;
            SplashAdvManager.Instance.ShowAdv();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            SDKManager.Instance.SaveData.Save();
        }
    }
}