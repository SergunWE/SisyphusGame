using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class GameContinuer : MonoBehaviour
    {
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
            GameInfo.Instance.MainPlatform.position = Vector3.Scale(GameInfo.Instance.StoneLastPoint,
                new Vector3(0, 1, 1));

            var rb = ActiveGameObjectStore.Instance.Stone.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            ActiveGameObjectStore.Instance.Stone.position =
                rb.position = GameInfo.Instance.StoneSpawnPoint.position;
            ActiveGameObjectStore.Instance.Stone.rotation = rb.rotation = Quaternion.identity;
            rb.isKinematic = false;
        }

        private void RollbackPlayer()
        {
            ActiveGameObjectStore.Instance.Player.position = GameInfo.Instance.PlayerSavePoint.position;
        }
    }
}