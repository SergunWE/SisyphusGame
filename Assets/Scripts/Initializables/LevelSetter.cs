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
    
    [SerializeField,Space] private Vector3 playerSpawnOffset;
    [SerializeField] private Vector3 stoneSpawnOffset;
    [SerializeField] private Vector3 islandSpawnOffset;
    
    [SerializeField,Space] private float parkourLevelOffset = 10f;
    [SerializeField] private float parkourIslandMinDistance = 1f;
    [SerializeField] private Vector3 parkourIslandOffset;
    [SerializeField] private Vector2 parkourIslandMaxOffset;
    [SerializeField] private List<GameObject> islands;

    [SerializeField,Space] private float slopeLevelOffset = 1f;
    [SerializeField] private float obstacleClearance = 3f;
    [SerializeField] private float obstacleVerticalOffset = 8f;
    [SerializeField] private float obstacleHorizontalOffset = 1f;
    [SerializeField] private List<GameObject> obstacles;
    
    private static SaveInfo SaveInfo => LocalYandexData.Instance.SaveInfo;
    
    public override void Initialize()
    {
        //level
        var startPosition = mainPlatformStartPos.position;
        float maxDistance = Vector3.Distance(startPosition, mainPlatformEndPos.position);
        var levelDirection = mainPlatformStartPos.forward;
        float levelDistance = Mathf.Clamp(slopeLevelOffset * SaveInfo.LevelNumber, 0, maxDistance);
        var levelPosition = startPosition + levelDirection * levelDistance;
        mainPlatform.transform.position = levelPosition;
        stone.position = levelPosition + stoneSpawnOffset;
        
        //obstacle
        for (float i = 0; i < levelDistance - obstacleClearance; i+= obstacleVerticalOffset)
        {
            var currentHorizontalOffset =
                new Vector3(Random.Range(-obstacleHorizontalOffset, obstacleHorizontalOffset), 0, 0);
            var obstaclePosition = startPosition + levelDirection * i + currentHorizontalOffset;
            int index = Random.Range(0, obstacles.Count - 1);
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
        while (currentDistance < islandDistance)
        {
            int index = Random.Range(0, islands.Count - 1);
            var offset = Vector3.zero;
            offset.x = Mathf.Abs(islandStartPos.position.x - currentIslandPosition.x) >= parkourIslandMaxOffset.x
                ? 0
                : Random.Range(parkourIslandOffset.x, -parkourIslandOffset.x);
            
            offset.y = Mathf.Abs(islandStartPos.position.y - currentIslandPosition.y) >= parkourIslandMaxOffset.y
                ? 0
                : Random.Range(parkourIslandOffset.y, -parkourIslandOffset.y);

            offset.z = Random.Range(parkourIslandMinDistance, parkourIslandOffset.z);
            currentIslandPosition += offset;
            Instantiate(islands[index], currentIslandPosition, Quaternion.identity);
            currentDistance += offset.z;
        }
    }
}
