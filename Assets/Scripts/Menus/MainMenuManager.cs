using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject loadingPanel;

        public void StartGame()
        {
            loadingPanel.SetActive(true);
            SceneManager.LoadSceneAsync(1);
        }
    }
}