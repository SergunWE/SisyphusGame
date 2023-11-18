using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class GameInfo : MonoBehaviourInitializable
    {
        public static GameInfo Instance { get; private set; }

        [field: SerializeField] public Transform MainPlatform { get; private set; }
        [field: SerializeField] public Transform PlayerSavePoint { get; set; }
        [field: SerializeField] public int CoinCount { get; set; }
        
        protected override void Initialize()
        {
            Instance = this;
        }
    }
}