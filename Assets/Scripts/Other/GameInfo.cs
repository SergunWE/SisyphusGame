using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class GameInfo : MonoBehaviourInitializable
    {
        public static GameInfo Instance { get; private set; }

        [field: SerializeField] public Transform MainPlatform { get; private set; }
        [field: SerializeField] public Transform StoneSpawnPoint { get; private set; }
        [field: SerializeField] public Transform PlayerSavePoint { get; set; }
        [field: SerializeField] public int CoinCount { get; set; }
        [field: SerializeField] public bool StoneFall { get; set; }
        [field: SerializeField] public Vector3 StoneLastPoint { get; private set; }

        private Transform _stone;
        private float _lastStoneSum;
        
        
        public override void Initialize()
        {
            Instance = this;
            _stone = ActiveGameObjectStore.Instance.Stone;
        }

        private void FixedUpdate()
        {
            var stoneCurrentPosition = _stone.position;
            float sum = stoneCurrentPosition.y + stoneCurrentPosition.z;
            if (!(sum >= _lastStoneSum)) return;
            StoneLastPoint = stoneCurrentPosition;
            _lastStoneSum = sum;
        }
    }
}