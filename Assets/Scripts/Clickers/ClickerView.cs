using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clickers
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text clickerText;
        [SerializeField] private Slider clickerSlider;

        private void Update()
        {
            clickerText.text = $"{(int)ClickerManager.CurrentClick} / {ClickerManager.TotalClick}";
            clickerSlider.value = ClickerManager.CurrentClick / ClickerManager.TotalClick;
        }
    }
}