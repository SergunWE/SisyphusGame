using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class StoneFallChecker : MonoBehaviourInitializable
    {
        [SerializeField] private float offset;

        private Transform _stone;

        private IEnumerator CheckStone()
        {
            while (_stone.position.y >= GameInfo.Instance.StoneLastPoint.y - offset)
            {
                yield return new WaitForSeconds(1f);
                yield return new WaitForEndOfFrame();
            }
            GameEvents.Instance.LoseGame(true);
        }

        public override void Initialize()
        {
            _stone = ActiveGameObjectStore.Instance.Stone;
            StartChecking();
        }
        

        public void StartChecking()
        {
            StopAllCoroutines();
            StartCoroutine(CheckStone());
        }
    }
}