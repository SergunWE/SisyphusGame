using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace YandexSDK.Scripts
{
    public class LocalYandexData
    {
        private static LocalYandexData _instance;
        public static LocalYandexData Instance => _instance ??= new LocalYandexData();
        
        public bool YandexDataLoaded { get; private set; }
        
        public List<MonoBehaviourInitializable> OnYandexDataLoaded = new();

        public SaveInfo SaveInfo { get; private set; }

        private LocalYandexData()
        {
            SaveInfo = new SaveInfo();
        }
        
        public void SetPlayerData(SaveInfo playerData)
        {
            YandexDataLoaded = true;
            if (playerData.LastSaveTimeTicks != 0)
            {
                SaveInfo = playerData;
            }

            Debug.Log("CALL OnYandexDataLoaded");
            foreach (var module in OnYandexDataLoaded.ToList())
            {
                module.TryInitialize();
            }
        }
        
        public void DebugSetPlayerData(SaveInfo playerData)
        {
            YandexDataLoaded = true;
            SaveInfo = playerData;
        }

        public void SaveData()
        {
            SaveInfo.LastSaveTimeTicks = DateTime.UtcNow.Ticks;
            YandexGamesManager.SavePlayerData(SaveInfo);
        }

        public void ResetProgress()
        {
            SaveInfo = new SaveInfo();
            YandexGamesManager.SavePlayerData(SaveInfo);
            foreach (var module in OnYandexDataLoaded.ToList())
            {
                module.TryInitialize();
            }
        }
    }
}