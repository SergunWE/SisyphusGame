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
            YandexGamesManager.SetToLeaderboard(LocalYandexData.Instance.SaveInfo.LevelNumber);
        }

        public void GoToMainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            LocalYandexData.Instance.SaveData();
            SplashAdvManager.Instance.ShowAdv();
            SceneManager.LoadSceneAsync(0);
        }

        public void ReloadGame()
        {
            Cursor.lockState = CursorLockMode.None;
            SplashAdvManager.Instance.ShowAdv();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}