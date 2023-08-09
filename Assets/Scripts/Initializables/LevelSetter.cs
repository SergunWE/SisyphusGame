using System;
using System.Collections.Generic;
using SkibidiRunner.Managers;
using UnityEngine;
using UnityEngine.Serialization;
using YandexSDK.Scripts;
using Random = UnityEngine.Random;

public class LevelSetter : MonoBehaviourInitializable
{
    [SerializeField] private Transform mainPlatformStartPos;
    [SerializeField] private Transform mainPlatformEndPos;
    [SerializeField] private Transform mainPlatform;
    [SerializeField] private Transform parkourPlatform;
    [SerializeField] private Transform islandStartPos;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody stone;

    [SerializeField, Space] private Vector3 playerSpawnOffset;
    [SerializeField] private Vector3 stoneSpawnOffset;
    [SerializeField] private Vector3 islandSpawnOffset;

    [SerializeField, Space] private float parkourLevelOffset = 10f;
    [SerializeField] private float parkourIslandMinDistance = 1f;
    [SerializeField] private float parkourIslandMinDistanceDiff;
    [SerializeField] private Vector3 parkourIslandOffset;
    [SerializeField] private Vector3 parkourIslandOffsetDiff;
    [SerializeField] private Vector2 parkourIslandMaxOffset;
    [SerializeField] private List<GameObject> islands;

    [SerializeField, Space] private float slopeLevelOffset = 1f;
    [SerializeField] private float obstacleClearance = 3f;
    [SerializeField] private float obstacleVerticalOffset = 8f;
    [SerializeField] private float obstacleHorizontalOffset = 1f;
    [SerializeField] private List<GameObject> obstacles;

    private static SaveInfo SaveInfo => LocalYandexData.Instance.SaveInfo;

    public override void Initialize()
    {
        Random.InitState(SaveInfo.LevelNumber);
        
        //level
        var startPosition = mainPlatformStartPos.position;
        float maxDistance = Vector3.Distance(startPosition, mainPlatformEndPos.position);
        var levelDirection = mainPlatformStartPos.forward;
        float levelDistance = Mathf.Clamp(slopeLevelOffset * SaveInfo.LevelNumber, 0, maxDistance);
        var levelPosition = startPosition + levelDirection * levelDistance;
        mainPlatform.transform.position = levelPosition;
        stone.position = levelPosition + stoneSpawnOffset;

        //obstacle
        for (float i = 0; i < levelDistance - obstacleClearance; i += obstacleVerticalOffset)
        {
            var currentHorizontalOffset =
                new Vector3(Random.Range(-obstacleHorizontalOffset, obstacleHorizontalOffset), 0, 0);
            var obstaclePosition = startPosition + levelDirection * i + currentHorizontalOffset;
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], obstaclePosition, Quaternion.identity);
        }

        //island
        float islandDistance = SaveInfo.LevelNumber * parkourLevelOffset;
        var islandDirection = parkourPlatform.forward * -1;
        var islandPosition = levelPosition + islandSpawnOffset + islandDirection * islandDistance;
        parkourPlatform.transform.position = islandPosition;
        player.transform.position = islandPosition + playerSpawnOffset;

        var currentIslandPosition = islandStartPos.position;
        float currentDistance = 0;

        float currentParkourIslandMinDistance =
            parkourIslandMinDistance + parkourIslandMinDistanceDiff * SaveInfo.LevelNumber;
        var currentParkourIslandOffset = parkourIslandOffset + parkourIslandOffsetDiff * SaveInfo.LevelNumber;

        while (currentDistance < islandDistance)
        {
            int index = Random.Range(0, islands.Count);
            var offset = Vector3.zero;
            offset.x = Random.Range(currentParkourIslandOffset.x, -currentParkourIslandOffset.x);
            if (Mathf.Abs(islandStartPos.position.x - currentIslandPosition.x - offset.x) >= parkourIslandMaxOffset.x)
            {
                offset.x *= -Mathf.Sign(islandStartPos.position.x);
            }

            offset.y = Random.Range(currentParkourIslandOffset.y, -currentParkourIslandOffset.y);
            if (Mathf.Abs(islandStartPos.position.y - currentIslandPosition.y - offset.y) >= parkourIslandMaxOffset.y)
            {
                offset.y *= Mathf.Sign(islandStartPos.position.y);
            }

            offset.z = Random.Range(currentParkourIslandMinDistance, currentParkourIslandOffset.z);
            currentIslandPosition += offset;
            Instantiate(islands[index], currentIslandPosition, Quaternion.identity);
            currentDistance += offset.z;
        }
    }
}