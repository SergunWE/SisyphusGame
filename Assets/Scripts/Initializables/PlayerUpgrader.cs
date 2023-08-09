using System;
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
        [SerializeField] private float pushOffset;
        
        private ThirdPersonController _playerController;
        private BasicRigidBodyPush _pushController;

        private static SaveInfo SaveInfo => LocalYandexData.Instance.SaveInfo;
        private static readonly Vector3 DefaultGravity;

        static PlayerUpgrader()
        {
            DefaultGravity = Physics.gravity;
        }

        public override void Initialize()
        {
            Physics.gravity = DefaultGravity + Vector3.up * SaveInfo.GravityLevel * gravityOffset;
            if (Physics.gravity.y > -0.1f)
            {
                Physics.gravity = new Vector3(Physics.gravity.x, -0.1f, Physics.gravity.z);
            }

            _playerController = ActiveGameObjectStore.Instance.Player.GetComponent<ThirdPersonController>();
            _pushController = ActiveGameObjectStore.Instance.Player.GetComponent<BasicRigidBodyPush>();

            _playerController.MoveSpeed += SaveInfo.SpeedLevel * walkOffset;
            _playerController.SprintSpeed += SaveInfo.SpeedLevel * sprintOffset;
            _playerController.Gravity = Physics.gravity.y;
            _playerController.JumpHeight += SaveInfo.GravityLevel * jumpOffset;
            _pushController.strength += SaveInfo.PushingForceLevel * pushOffset;
        }
    }
}