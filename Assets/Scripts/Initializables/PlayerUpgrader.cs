using System;
using SDKNewRealization;
using SkibidiRunner.Managers;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

namespace SkibidiRunner.Managers
{
    public class PlayerUpgrader : MonoBehaviourInitializable
    {
        [SerializeField] private float walkOffset;
        [SerializeField] private float sprintOffset;
        [SerializeField] private float gravityOffset;
        [SerializeField] private float jumpOffset;
        
        private ThirdPersonController _playerController;

        private static StoredData SaveInfo => SDKManager.Instance.SaveData.CurrentData;
        private static readonly Vector3 DefaultGravity;

        static PlayerUpgrader()
        {
            DefaultGravity = Physics.gravity;
        }

        protected override void Initialize()
        {
            Physics.gravity = DefaultGravity + Vector3.up * SaveInfo.GravityLevel * gravityOffset;
            if (Physics.gravity.y > -1f)
            {
                Physics.gravity = new Vector3(Physics.gravity.x, -1f, Physics.gravity.z);
            }

            _playerController = ActiveGameObjectStore.Instance.Player.GetComponent<ThirdPersonController>();

            _playerController.MoveSpeed += SaveInfo.SpeedLevel * walkOffset;
            _playerController.SprintSpeed += SaveInfo.SpeedLevel * sprintOffset;
            _playerController.Gravity = Physics.gravity.y;
            _playerController.JumpHeight += SaveInfo.GravityLevel * jumpOffset;
        }
    }
}