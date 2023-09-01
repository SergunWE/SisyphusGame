using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class GameEvents : MonoBehaviourInitializable
    {
        public static GameEvents Instance { get; private set; }
        
        [SerializeField] private UnityEvent gameWin;
        [SerializeField] private UnityEvent gameLose;
        [SerializeField] private UnityEvent gameContinue;
        [SerializeField] private UnityEvent coinCollect;

        private bool _gameWined;
        private bool _gameLost;
        
        protected override void Initialize()
        {
            Instance = this;
        }

        public void WinGame()
        {
            if(_gameLost || _gameWined) return;
            Debug.Log("Game win");
            _gameWined = true;
            gameWin?.Invoke();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void LoseGame(bool stoneFell)
        {
            if(_gameLost || _gameWined) return;
            Debug.Log(stoneFell ? "Game lose stone" : "Game lose player");
            _gameLost = true;
            GameInfo.Instance.StoneFall = stoneFell;

            gameLose?.Invoke();
        }

        public void ContinueGame()
        {
            gameContinue?.Invoke();
            _gameLost = false;
        }

        public void CoinCollected()
        {
            LocalYandexData.Instance.SaveInfo.Coins++;
            GameInfo.Instance.CoinCount++;
            coinCollect?.Invoke();
        }
    }
}