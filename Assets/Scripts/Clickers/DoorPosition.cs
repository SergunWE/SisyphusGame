using SkibidiRunner.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Clickers
{
    public class DoorPosition : MonoBehaviourInitializable
    {
        [SerializeField] private Vector3 doorPositionOffset;
        
        private Vector3 _startPosition;

        protected override void Initialize()
        {
            _startPosition = transform.position;
            transform.position = _startPosition + new Vector3()
            {
                x = Random.Range(-doorPositionOffset.x, doorPositionOffset.x),
                y = Random.Range(-doorPositionOffset.y, doorPositionOffset.y),
                z = Random.Range(-doorPositionOffset.z, doorPositionOffset.z)
            };
        }
    }
}