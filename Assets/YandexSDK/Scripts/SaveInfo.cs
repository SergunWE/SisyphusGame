using System;
using UnityEngine;

namespace YandexSDK.Scripts
{
    [Serializable]
    public class SaveInfo
    {
        //level
        [field: SerializeField] public int LevelNumber { get; set; }

        //settings
        [field: SerializeField] public bool MusicOn { get; set; } = true;
        [field: SerializeField] public bool SoundOn { get; set; } = true;
        [field: SerializeField] public string ManualLanguage { get; set; }

        //pumping
        [field: SerializeField] public int Coins { get; set; }
        [field: SerializeField] public int DailyRewardLevel { get; set; }
        [field: SerializeField] public long DailyRewardTimeTicks { get; set; }
        [field: SerializeField] public int SpeedLevel { get; set; }
        [field: SerializeField] public int GravityLevel { get; set; }
        [field: SerializeField] public int PushingForceLevel { get; set; }

        //other
        [field: SerializeField] public Color PlayerColor { get; set; } = Color.white;
        [field: SerializeField] public long LastSaveTimeTicks { get; set; }
        
        //customization
        [field: SerializeField] public int PlayerSkinIndex { get; set; }
        [field: SerializeField] public int StoneSkinIndex { get; set; }
    }
}