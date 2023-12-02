using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SDKNewRealization
{
    public class AndroidSaveData : ISaveData
    {
        public event Action DataLoaded;
        public bool IsDataLoaded { get; private set; }
        public StoredData CurrentData { get; private set; }
        
        private readonly string _saveKey;
        
        public AndroidSaveData(string saveKey)
        {
            _saveKey = saveKey;
            CurrentData = new StoredData();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(CurrentData);
            PlayerPrefs.SetString(_saveKey, json);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            string json = PlayerPrefs.GetString(_saveKey);
            var loadedData = JsonConvert.DeserializeObject<StoredData>(json);
            if (loadedData == null || loadedData.LastSaveTimeTicks == 0) return;
            CurrentData = JsonConvert.DeserializeObject<StoredData>(json);
            IsDataLoaded = true;
            DataLoaded?.Invoke();
        }

        public void DebugSetData(StoredData data)
        {
            CurrentData = data;
            IsDataLoaded = true;
            DataLoaded?.Invoke();
        }
    }
}