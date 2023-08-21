using TMPro;
using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class LevelNumberView : MonoBehaviourInitializable
    {
        [SerializeField] private TMP_Text text;
        
        public override void Initialize()
        {
            text.text = (LocalYandexData.Instance.SaveInfo.LevelNumber + 1).ToString();
        }
    }
}