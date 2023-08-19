using System;
using System.Collections;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class PlayerFallChecker: MonoBehaviourInitializable
    {
        [SerializeField] private float offset;

        private float _startHeight;
        private Transform _player;
        private bool _checking;
        
        public override void Initialize()
        {
            _player = ActiveGameObjectStore.Instance.Player;
            _startHeight = _player.position.y;
            StartChecking();
        }
        
        public void StartChecking()
        {
            _checking = true;
        }

        private void FixedUpdate()
        {
            if (!_checking || !(_player.position.y + offset < _startHeight)) return;
            _checking = false;
            GameEvents.Instance.LoseGame(false);
        }
    }
}