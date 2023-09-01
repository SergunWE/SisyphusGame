using UnityEngine;
using UnityEngine.Serialization;

namespace SkibidiRunner.Managers
{
    public class GameContinuer : MonoBehaviour
    {
        [SerializeField] private Transform direction;
        [SerializeField] private Vector3 recoveryOffset; 
        
        public void RollbackGame()
        {
            if (GameInfo.Instance.StoneFall)
            {
                RollbackStone();
            }
            RollbackPlayer();
        }

        private void RollbackStone()
        {
            Vector3 targetPosition = new Vector3(
                0,
                GameInfo.Instance.StoneLastPoint.y,
                GameInfo.Instance.StoneLastPoint.z
            );

            // Calculate the required distance to move along the forwardDirection
            var position = GameInfo.Instance.MainPlatform.position;
            var forward = direction.forward;
            float distanceToMove = Vector3.Dot(targetPosition - position, forward);

            // Move the platform along the forwardDirection to the target position
            position += forward * distanceToMove;
            GameInfo.Instance.MainPlatform.position = position + recoveryOffset;


            // GameInfo.Instance.MainPlatform.position = Vector3.Scale(GameInfo.Instance.StoneLastPoint,
            //     new Vector3(0, 1, 1));

            var rb = ActiveGameObjectStore.Instance.Stone.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            ActiveGameObjectStore.Instance.Stone.position =
                rb.position = GameInfo.Instance.StoneSpawnPoint.position;
            ActiveGameObjectStore.Instance.Stone.rotation = rb.rotation = Quaternion.identity;
            rb.isKinematic = false;
        }

        private void RollbackPlayer()
        {
            //workaround
            ActiveGameObjectStore.Instance.Player.gameObject.SetActive(false);
            ActiveGameObjectStore.Instance.Player.position = GameInfo.Instance.PlayerSavePoint.position;
            ActiveGameObjectStore.Instance.Player.gameObject.SetActive(true);
        }
    }
}