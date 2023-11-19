using System;
using System.Threading.Tasks;
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
            LocalYandexData.Instance.SaveData();
            SceneManager.LoadSceneAsync(1);
        }
    }
}