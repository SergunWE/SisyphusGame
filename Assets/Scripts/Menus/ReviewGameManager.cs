using System;
using UnityEngine;
using YandexSDK.Scripts;

namespace Menus
{
    public class ReviewGameManager : MonoBehaviour
    {
        [SerializeField] private int delaySeconds;
        private static readonly DateTime StartTime;

        private static bool _reviewShowed;
        
        static ReviewGameManager()
        {
            StartTime = DateTime.UtcNow;
        }

        private void Start()
        {
            if (DateTime.UtcNow - StartTime <= TimeSpan.FromSeconds(delaySeconds) || _reviewShowed) return;
            //YandexGamesManager.RequestReviewGame();
            _reviewShowed = true;
        }
    }
}