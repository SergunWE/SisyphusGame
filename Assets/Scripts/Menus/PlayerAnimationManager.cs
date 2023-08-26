using System;
using SkibidiRunner.Managers;
using UnityEngine;

namespace Menus
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int CoinUpdate = Animator.StringToHash("PlayerJoy");

        private void OnEnable()
        {
            ShopManager.Instance.CoinAdded += PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful += PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful += PlayerJoy;
        }

        private void OnDisable()
        {
            ShopManager.Instance.CoinAdded -= PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful -= PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful -= PlayerJoy;
        }
        
        private void PlayerJoy()
        {
            animator.SetTrigger(CoinUpdate);
        }
    }
}