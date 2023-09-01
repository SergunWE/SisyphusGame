using UnityEngine;
using UnityEngine.SceneManagement;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private SplashAdvManager splashAdvManager;
        
        public void GoToNext()
        {
            LocalYandexData.Instance.SaveInfo.LevelNumber++;
        }

        public void GoToMainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            LocalYandexData.Instance.SaveData();
            splashAdvManager.ShowAdv();
            SceneManager.LoadSceneAsync(0);
        }

        public void ReloadGame()
        {
            splashAdvManager.ShowAdv();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}