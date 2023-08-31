using System;
using UnityEngine;
using UnityEngine.Events;

namespace SkibidiRunner.Managers
{
    public class AdsShopManager : MonoBehaviour
    {
        public static AdsShopManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void GetSpeed(int result)
        {
            switch (result)
            {
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    ShopManager.Instance.BuySkill(Skill.Speed, 0);
                    break;
                case 2:
                    PauseManager.Instance.ResumeGame();
                    break;
            }
        }
        
        public void GetJump(int result)
        {
            switch (result)
            {
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    ShopManager.Instance.BuySkill(Skill.Jump, 0);
                    break;
                case 2:
                    PauseManager.Instance.ResumeGame();
                    break;
            }
        }
        
        public void GetPower(int result)
        {
            switch (result)
            {
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    ShopManager.Instance.BuySkill(Skill.Power, 0);
                    break;
                case 2:
                    PauseManager.Instance.ResumeGame();
                    break;
            }
        }
    }
}