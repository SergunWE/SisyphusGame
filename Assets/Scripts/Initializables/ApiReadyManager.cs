using UnityEngine;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class ApiReadyManager : MonoBehaviourInitializable
    {
        private static bool _called;
        
        protected override void Initialize()
        {
            if(_called) return;
            _called = true;
            //YandexGamesManager.ApiReady();
        }
    }
}