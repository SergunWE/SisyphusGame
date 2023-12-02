using System;

namespace SDKNewRealization
{
    public interface ISaveData
    {
        event Action DataLoaded;
        bool IsDataLoaded { get; }
        
        StoredData CurrentData { get; }
        
        void Save();
        void Load();
        void DebugSetData(StoredData data);
    }
}