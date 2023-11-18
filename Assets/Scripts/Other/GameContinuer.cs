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
            RollbackPlayer();
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