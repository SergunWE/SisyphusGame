using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private Transform mainPlatformStartPos;
    [SerializeField] private Transform mainPlatformEndPos;
    [SerializeField] private Transform mainPlatform;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody stone;

    [SerializeField] private Vector3 playerSpawnOffset;
    [SerializeField] private Vector3 stoneSpawnOffset;

    [SerializeField] private float levelOffset = 10f;
    [SerializeField] private int level = 0;

    private void Awake()
    {
        var startPosition = mainPlatformStartPos.position;
        var maxDistance = Vector3.Distance(startPosition, mainPlatformEndPos.position);
        Debug.Log($"Platform distance {maxDistance}");
        var direction = mainPlatformStartPos.forward;
        var levelDistance = Mathf.Clamp(levelOffset * level, 0, maxDistance);
        var position = startPosition + direction * levelDistance;
        mainPlatform.transform.position = position;
        player.transform.position = position + playerSpawnOffset;
        stone.position = position + stoneSpawnOffset;
    }
}
