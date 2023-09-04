using System;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Menus
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField, Space] private UnityEvent coinChanged;
        
        private static readonly int CoinSpending = Animator.StringToHash("PlayerJoy");
        private static readonly int SkinBought = Animator.StringToHash("PlayerSkinBuy");


        private void OnEnable()
        {
            ShopManager.Instance.CoinAdded += PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful += PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful += PlayerJoy2;
        }

        private void OnDisable()
        {
            ShopManager.Instance.CoinAdded -= PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful -= PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful -= PlayerJoy2;
        }

        private void PlayerJoy()
        {
            animator.SetTrigger(CoinSpending);
            coinChanged?.Invoke();
        }

        private void PlayerJoy2()
        {
            animator.SetTrigger(SkinBought);
            coinChanged?.Invoke();
        }
    }
}