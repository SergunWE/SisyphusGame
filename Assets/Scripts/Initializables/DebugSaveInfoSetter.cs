using SDKNewRealization;
using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

public class DebugSaveInfoSetter : MonoBehaviourInitializable
{
    [SerializeField] private StoredData saveInfo;

    private static bool _set;

    protected override void Initialize()
    {
#if UNITY_EDITOR
        if (_set)
        {
            saveInfo = SDKManager.Instance.SaveData.CurrentData;
        }
        else
        {
            saveInfo.LastSaveTimeTicks = 1;
            SDKManager.Instance.SaveData.DebugSetData(saveInfo);
            _set = true;
        }
#endif
    }
}