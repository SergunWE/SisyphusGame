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
        
        private IEnumerator CheckPlayer()
        {
            while (_player.position.y + offset >= _startHeight)
            {
                yield return new WaitForSeconds(1f);
                yield return new WaitForEndOfFrame();
            }
            GameEvents.Instance.LoseGame(false);
        }
        
        public override void Initialize()
        {
            _player = ActiveGameObjectStore.Instance.Player;
            _startHeight = _player.position.y;
            StartChecking();
        }
        
        public void StartChecking()
        {
            StopAllCoroutines();
            StartCoroutine(CheckPlayer());
        }
    }
}