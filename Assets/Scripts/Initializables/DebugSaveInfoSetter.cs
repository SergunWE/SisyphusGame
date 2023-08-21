using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

public class DebugSaveInfoSetter : MonoBehaviourInitializable
{
    [SerializeField] private SaveInfo saveInfo;

    private static bool _set;

    public override void Initialize()
    {
        if (_set)
        {
            saveInfo = LocalYandexData.Instance.SaveInfo;
        }
        else
        {
            saveInfo.LastSaveTimeTicks = 1;
            LocalYandexData.Instance.DebugSetPlayerData(saveInfo);
            _set = true;
        }
    }
}