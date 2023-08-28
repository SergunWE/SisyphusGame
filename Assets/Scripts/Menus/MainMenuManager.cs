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

        public void StartGame()
        {
            loadingPanel.SetActive(true);
            LocalYandexData.Instance.SaveData();
            SceneManager.LoadSceneAsync(1);
        }
    }
}