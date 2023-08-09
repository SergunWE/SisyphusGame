using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class GameInfo : MonoBehaviourInitializable
    {
        public static GameInfo Instance { get; private set; }

        [SerializeField] private Transform stone;
        [SerializeField] private Transform player;

        [field: SerializeField] public int CoinCount { get; set; }
        [field: SerializeField] public Vector3 PlayerSavePoint { get; set; }
        [field: SerializeField] public Vector3 StoneLastPoint { get; private set; }

        private float _lastStoneSum;

        private void Awake()
        {
            Instance = this;
        }
        
        public override void Initialize()
        {
            PlayerSavePoint = player.position;
        }

        private void FixedUpdate()
        {
            var stoneCurrentPosition = stone.position;
            float sum = stoneCurrentPosition.x + stoneCurrentPosition.y + stoneCurrentPosition.z;
            if (!(sum >= _lastStoneSum)) return;
            StoneLastPoint = stoneCurrentPosition;
            _lastStoneSum = sum;
        }
    }
}