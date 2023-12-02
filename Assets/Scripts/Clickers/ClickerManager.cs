using SDKNewRealization;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using YandexSDK.Scripts;

namespace Clickers
{
    public class ClickerManager : MonoBehaviourInitializable
    {
        [SerializeField] private int startOffset;
        [SerializeField] private int levelOffset;
        [SerializeField] private float levelMultiplyOffset;
        [SerializeField] private float startPowerOffset;
        [SerializeField] private float upgradePowerOffset;

        [SerializeField] private UnityEvent clicked;
        
        public static int TotalClick { get; private set; }
        public static float CurrentClick { get; private set; }

        private float _clickPower;
        private bool _start;
        
        protected override void Initialize()
        {
            CurrentClick = 0;
            _clickPower = startPowerOffset + SDKManager.Instance.SaveData.CurrentData.ClickPowerLevel * upgradePowerOffset;
            TotalClick = startOffset + SDKManager.Instance.SaveData.CurrentData.LevelNumber * levelOffset;
            TotalClick = (int)(TotalClick * levelMultiplyOffset);
        }

        public void StartClick()
        {
            _start = true;
        }

        public void StopClick()
        {
            _start = false;
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (!context.started || !_start) return;
            CurrentClick += _clickPower;
            clicked?.Invoke();
            if (CurrentClick >= TotalClick)
            {
                GameEvents.Instance.WinGame();
            }
        }

        public void Click()
        {
            if (!_start) return;
            CurrentClick += _clickPower;
            clicked?.Invoke();
            if (CurrentClick >= TotalClick)
            {
                GameEvents.Instance.WinGame();
            }
        }
    }
}