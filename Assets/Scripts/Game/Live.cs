using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

namespace Game
{
    public class Live : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        
        public void BuyContinueAds()
        {
            GameEvents.Instance.ContinueGame();
            losePanel.SetActive(false);
        }
    }
}