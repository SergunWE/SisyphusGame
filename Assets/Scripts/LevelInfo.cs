using System;
using UnityEngine;

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
    [field: SerializeField] public int WalkingSpeedLevel { get; set; }
    [field: SerializeField] public int SprintSpeedLevel { get; set; }
    [field: SerializeField] public int GravityLevel { get; set; }
    [field: SerializeField] public int PushingForceLevel { get; set; }
}