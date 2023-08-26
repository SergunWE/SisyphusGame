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

        public async void StartGame()
        {
            loadingPanel.SetActive(true);
            LocalYandexData.Instance.SaveData();
            await Task.Delay(100);
            SceneManager.LoadSceneAsync(1);
        }
    }
}