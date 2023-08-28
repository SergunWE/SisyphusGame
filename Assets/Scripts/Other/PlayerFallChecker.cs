using System;
using System.Collections;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerFallChecker: MonoBehaviourInitializable
    {
        [SerializeField] private float offset;
        [SerializeField] private float levelOffset;

        private float _startHeight;
        private Transform _player;
        private bool _checking;

        private float _finalOffset;
        
        protected override void Initialize()
        {
            _player = ActiveGameObjectStore.Instance.Player;
            _startHeight = _player.position.y;
            StartChecking();
        }
        
        public void StartChecking()
        {
            _finalOffset = offset + levelOffset * LocalYandexData.Instance.SaveInfo.LevelNumber;
            _checking = true;
        }

        private void FixedUpdate()
        {
            if (!_checking || !(_player.position.y + _finalOffset < _startHeight)) return;
            _checking = false;
            GameEvents.Instance.LoseGame(false);
        }
    }
}