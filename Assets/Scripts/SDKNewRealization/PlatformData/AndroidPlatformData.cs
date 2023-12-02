using System.Globalization;
using UnityEngine;

namespace SDKNewRealization
{
    public class AndroidPlatformData : IPlatformData
    {
        public string LanguageCode => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        public DeviceType DeviceType => DeviceType.Mobile;
    }
}