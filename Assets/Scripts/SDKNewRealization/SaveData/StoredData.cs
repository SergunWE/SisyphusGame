using System;
using System.Collections.Generic;
using UnityEngine;

namespace SDKNewRealization
{
    /// <summary>
    /// Data that is downloaded and stored from outside
    /// </summary>
    [Serializable]
    public class StoredData
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
        [field: SerializeField] public int ClickPowerLevel { get; set; }
        [field: SerializeField] public long LastSaveTimeTicks { get; set; }

        //customization
        [field: SerializeField] public int PlayerSkinId { get; set; }
        [field: SerializeField] public List<int> PlayerPurchasedSkins { get; set; } = new() { 0 };
    }
}