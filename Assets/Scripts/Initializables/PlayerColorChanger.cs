using UnityEngine;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerColorChanger : MonoBehaviourInitializable
    {
        protected override void Initialize()
        {
            // ActiveGameObjectStore.Instance.Player.gameObject.GetComponentInChildren<Renderer>().sharedMaterial.color =
            //     LocalYandexData.Instance.SaveInfo.PlayerColor;
        }
    }
}