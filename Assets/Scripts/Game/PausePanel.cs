using System;
using SkibidiRunner.Managers;
using StarterAssets;
using UnityEngine;

namespace Game
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Animation panelAnimation;
        [SerializeField] private StarterAssetsInputs starterAssetsInputs;
        [SerializeField] private CursorLocker cursorLocker;

        private void OnEnable()
        {
            starterAssetsInputs.SetInputEnable(false);
            panelAnimation.Play();
        }

        public void Close()
        {
            if (GameEvents.Instance.GameLost || GameEvents.Instance.GameLost) return;
            cursorLocker.SetCursorState(true);
            starterAssetsInputs.SetInputEnable(true);
        }
    }
}