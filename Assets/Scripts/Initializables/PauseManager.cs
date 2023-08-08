﻿using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class PauseManager : MonoBehaviour
    {
        private float _timeScale;

        private void Awake()
        {
            _timeScale = Time.timeScale;
        }

        public void SetNewTimeScale(float value)
        {
            _timeScale = value;
        }

        public void PauseGame()
        {
            if(!enabled) return;
            _timeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
        }

        public void ResumeGame()
        {
            if(!enabled) return;
            Time.timeScale = _timeScale;
            AudioListener.pause = false;
        }
    }
}