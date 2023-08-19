using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class StoneFallChecker : MonoBehaviourInitializable
    {
        [SerializeField] private float offset;

        private Transform _stone;
        private bool _checking;

        public override void Initialize()
        {
            _stone = ActiveGameObjectStore.Instance.Stone;
            StartChecking();
        }

        public void StartChecking()
        {
            _checking = true;
        }

        private void FixedUpdate()
        {
            if (!_checking || !(_stone.position.y < GameInfo.Instance.StoneLastPoint.y - offset)) return;
            _checking = false;
            GameEvents.Instance.LoseGame(true);
        }
    }
}