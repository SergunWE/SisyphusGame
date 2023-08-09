using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SkibidiRunner.Managers
{
    public class GameEvents : MonoBehaviour
    {
        public UnityEvent gameWin;
        public UnityEvent gameLose;
        public UnityEvent gameContinue;
    }
}