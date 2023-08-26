using System;
using SkibidiRunner.Managers;
using UnityEngine;

namespace Menus
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int CoinUpdate = Animator.StringToHash("CoinUpdate");

        private void OnEnable()
        {
            ShopManager.Instance.CoinCountUpdate += InstanceOnCoinCountUpdate;
        }

        private void OnDisable()
        {
            ShopManager.Instance.CoinCountUpdate -= InstanceOnCoinCountUpdate;
        }
        
        private void InstanceOnCoinCountUpdate()
        {
            animator.SetTrigger(CoinUpdate);
        }
    }
}