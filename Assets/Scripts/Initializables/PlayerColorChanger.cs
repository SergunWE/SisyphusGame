using UnityEngine;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerColorChanger : MonoBehaviourInitializable
    {
        [SerializeField] private Renderer playerRenderer;
        
        public override void Initialize()
        {
            playerRenderer.sharedMaterial.color = LocalYandexData.Instance.SaveInfo.PlayerColor;
        }
    }
}