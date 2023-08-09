using System;
using UnityEngine;

namespace SkibidiRunner.Managers
{
    public class ActiveGameObjectStore : MonoBehaviourInitializable
    {
        public static ActiveGameObjectStore Instance { get; private set; }
        
        [field:SerializeField] public Transform Stone { get; private set; }
        [field:SerializeField] public Transform Player { get; private set; }

        public override void Initialize()
        {
            Instance = this;
        }
    }
}