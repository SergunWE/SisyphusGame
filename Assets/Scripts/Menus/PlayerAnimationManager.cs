using System;
using SkibidiRunner.Managers;
using UnityEngine;

namespace Menus
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int CoinSpending = Animator.StringToHash("PlayerJoy");
        private static readonly int SkinBought = Animator.StringToHash("PlayerSkinBuy");


        private void OnEnable()
        {
            ShopManager.Instance.CoinCountUpdate += PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful += PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful += PlayerJoy2;
        }

        private void OnDisable()
        {
            ShopManager.Instance.CoinCountUpdate -= PlayerJoy;
            ShopManager.Instance.SkillPurchaseSuccessful -= PlayerJoy;
            ShopManager.Instance.SkinPurchaseSuccessful -= PlayerJoy2;
        }

        private void PlayerJoy()
        {
            animator.SetTrigger(CoinSpending);
        }

        private void PlayerJoy2()
        {
            animator.SetTrigger(SkinBought);
        }
    }
}