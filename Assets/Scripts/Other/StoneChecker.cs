using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class StoneChecker :  MonoBehaviour
    {
        [SerializeField] private Transform stone;
        [SerializeField] private Transform player;
        [SerializeField] private GameEvents gameEvents;
        [SerializeField] private float offset;

        private void FixedUpdate()
        {
            if (stone.position.y + offset < player.position.y)
            {
                gameEvents.gameLose?.Invoke();
            }
        }
    }
}