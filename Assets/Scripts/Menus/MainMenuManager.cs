using System;
using System.Threading.Tasks;
using SDKNewRealization;
using UnityEngine;
using UnityEngine.SceneManagement;
using YandexSDK.Scripts;

namespace Menus
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject loadingPanel;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        public void StartGame()
        {
            loadingPanel.SetActive(true);
            SDKManager.Instance.SaveData.Save();
            SceneManager.LoadSceneAsync(2);
        }
    }
}