using System;
using System.Collections.Generic;
using UnityEngine;
using YandexSDK.Scripts;
using Random = UnityEngine.Random;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private Transform mainPlatformStartPos;
    [SerializeField] private Transform mainPlatformEndPos;
    [SerializeField] private Transform mainPlatform;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody stone;
    
    [SerializeField,Space] private Vector3 playerSpawnOffset;
    [SerializeField] private Vector3 stoneSpawnOffset;
    [SerializeField] private float levelOffset = 10f;

    [SerializeField] private float obstacleClearance = 3f;
    [SerializeField] private float obstacleVerticalOffset = 8f;
    [SerializeField] private float obstacleHorizontalOffset = 1f;
    [SerializeField] private List<GameObject> obstacles;
    
    private static SaveInfo SaveInfo => LocalYandexData.Instance.SaveInfo;

    private void Awake()
    {
        //level
        var startPosition = mainPlatformStartPos.position;
        float maxDistance = Vector3.Distance(startPosition, mainPlatformEndPos.position);
        var direction = mainPlatformStartPos.forward;
        float levelDistance = Mathf.Clamp(levelOffset * SaveInfo.LevelNumber, 0, maxDistance);
        var position = startPosition + direction * levelDistance;
        mainPlatform.transform.position = position;
        player.transform.position = position + playerSpawnOffset;
        stone.position = position + stoneSpawnOffset;
        
        //obstacle
        for (float i = 0; i < levelDistance - obstacleClearance; i+= obstacleVerticalOffset)
        {
            var currentHorizontalOffset =
                new Vector3(Random.Range(-obstacleHorizontalOffset, obstacleHorizontalOffset), 0, 0);
            var obstaclePosition = startPosition + direction * i + currentHorizontalOffset;
            int index = Random.Range(0, obstacles.Count - 1);
            Instantiate(obstacles[index], obstaclePosition, Quaternion.identity);
        }
    }
}
