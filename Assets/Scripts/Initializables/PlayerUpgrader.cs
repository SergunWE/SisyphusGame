using System;
using SkibidiRunner.Managers;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using YandexSDK.Scripts;

public class PlayerUpgrader : MonoBehaviourInitializable
{
    [SerializeField] private ThirdPersonController playerController;
    [SerializeField] private BasicRigidBodyPush pushController;
    
    [SerializeField, Space] private float walkOffset;
    [SerializeField] private float sprintOffset;
    [SerializeField] private float gravityOffset;
    [SerializeField] private float jumpOffset;
    [SerializeField] private float pushOffset;

    private static SaveInfo SaveInfo => LocalYandexData.Instance.SaveInfo;
    private static readonly Vector3 DefaultGravity;

    static PlayerUpgrader()
    {
        DefaultGravity = Physics.gravity;
    }
    
    public override void Initialize()
    {
        Physics.gravity = DefaultGravity + Vector3.up * SaveInfo.GravityLevel * gravityOffset;
        
        playerController.MoveSpeed += SaveInfo.SpeedLevel * walkOffset;
        playerController.SprintSpeed += SaveInfo.SpeedLevel * sprintOffset;
        playerController.Gravity = Physics.gravity.y;
        playerController.JumpHeight += SaveInfo.GravityLevel * jumpOffset;
        pushController.strength += SaveInfo.PushingForceLevel * pushOffset;
    }
}