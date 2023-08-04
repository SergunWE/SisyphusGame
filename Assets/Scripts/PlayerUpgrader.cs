using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private ThirdPersonController playerController;
    [SerializeField] private BasicRigidBodyPush pushController;
    
    [SerializeField, Space] private float walkOffset;
    [SerializeField] private float sprintOffset;
    [SerializeField] private float gravityOffset;
    [SerializeField] private float jumpOffset;
    [SerializeField] private float pushOffset;

    //todo: use singleton
    [SerializeField] private SaveInfo saveInfo;
    
    private static readonly Vector3 DefaultGravity;

    static PlayerUpgrader()
    {
        DefaultGravity = Physics.gravity;
    }
    
    private void Awake()
    {
        Physics.gravity = DefaultGravity + Vector3.up * saveInfo.GravityLevel * gravityOffset;
        
        playerController.MoveSpeed += saveInfo.WalkingSpeedLevel * walkOffset;
        playerController.SprintSpeed += saveInfo.WalkingSpeedLevel * sprintOffset;
        playerController.Gravity = Physics.gravity.y;
        playerController.JumpHeight += saveInfo.GravityLevel * jumpOffset;
        pushController.strength += saveInfo.PushingForceLevel * pushOffset;
    }
}