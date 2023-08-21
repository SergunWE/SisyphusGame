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

        public void GoToMainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            LocalYandexData.Instance.SaveData();
            SceneManager.LoadSceneAsync(0);
        }
    }
}