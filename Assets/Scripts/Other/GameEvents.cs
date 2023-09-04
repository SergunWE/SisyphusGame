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

        public bool GameWined { get; private set; }
        public bool GameLost { get; private set; }
        
        protected override void Initialize()
        {
            Instance = this;
        }

        public void WinGame()
        {
            if(GameLost || GameWined) return;
            Debug.Log("Game win");
            GameWined = true;
            gameWin?.Invoke();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void LoseGame(bool stoneFell)
        {
            if(GameLost || GameWined) return;
            Debug.Log(stoneFell ? "Game lose stone" : "Game lose player");
            GameLost = true;
            GameInfo.Instance.StoneFall = stoneFell;

            gameLose?.Invoke();
        }

        public void ContinueGame()
        {
            gameContinue?.Invoke();
            GameLost = false;
        }

        public void CoinCollected()
        {
            LocalYandexData.Instance.SaveInfo.Coins++;
            GameInfo.Instance.CoinCount++;
            coinCollect?.Invoke();
        }
    }
}