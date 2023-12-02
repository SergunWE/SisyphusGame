// using System;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.Serialization;
// using YandexSDK.Scripts;
//
// namespace SkibidiRunner.Managers
// {
//     public class SplashAdvManager : MonoBehaviour
//     {
//        public static SplashAdvManager Instance { get; private set; }
//         
//         [SerializeField] private bool showStartup;
//         [SerializeField] private int delayStartup;
//         [SerializeField] private int delaySeconds;
//
//         private static DateTime _adsTime;
//         private static readonly DateTime StartTime;
//
//         private bool _prevPause;
//
//         static SplashAdvManager()
//         {
//             StartTime = DateTime.UtcNow;
//         }
//
//         private void Awake()
//         {
//             if (Instance == null)
//             {
//                 Instance = this;
//                 DontDestroyOnLoad(gameObject);
//             }
//             else
//             {
//                 Destroy(gameObject);
//             }
//         }
//
//         private void Start()
//         {
//             if (showStartup)
//             {
//                 ShowAdv();
//             }
//         }
//
//         public void ShowAdv()
//         {
//             if (DateTime.UtcNow - StartTime <= TimeSpan.FromSeconds(delayStartup)) return;
//             if (DateTime.UtcNow - _adsTime > TimeSpan.FromSeconds(delaySeconds))
//             {
//                 YandexGamesManager.ShowSplashAdv(gameObject, nameof(AdvCallback));
//             }
//         }
//
//         public void AdvCallback(int result)
//         {
//             switch (result)
//             {
//                 case 0:
//                     _prevPause = Cursor.lockState == CursorLockMode.Locked;
//                     Cursor.lockState = CursorLockMode.None;
//                     PauseManager.Instance.PauseGame();
//                     break;
//                 case 1:
//                     Cursor.lockState = _prevPause ? CursorLockMode.Locked : CursorLockMode.None;
//                     PauseManager.Instance.ResumeGame();
//                     _adsTime = DateTime.UtcNow;
//                     break;
//             }
//         }
//     }
// }