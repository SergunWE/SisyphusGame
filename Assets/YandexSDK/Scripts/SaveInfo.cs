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
        [field: SerializeField] public bool MusicOn { get; set; }
        [field: SerializeField] public bool SoundOn { get; set; }

        //pumping
        [field: SerializeField] public int Coins { get; set; }
        [field: SerializeField] public int DailyRewardLevel { get; set; }
        [field: SerializeField] public ulong DailyRewardTimeTicks { get; set; }
        [field: SerializeField] public int SpeedLevel { get; set; }
        [field: SerializeField] public int GravityLevel { get; set; }
        [field: SerializeField] public int PushingForceLevel { get; set; }

        //other
        [field: SerializeField] public long LastSaveTimeTicks { get; set; }

        public SaveInfo()
        {
            LevelNumber = 0;
            MusicOn = true;
            SoundOn = true;
            Coins = 0;
            DailyRewardLevel = 0;
            DailyRewardTimeTicks = 0;
            SpeedLevel = 0;
            GravityLevel = 0;
            PushingForceLevel = 0;
            LastSaveTimeTicks = 0;
        }
    }
}