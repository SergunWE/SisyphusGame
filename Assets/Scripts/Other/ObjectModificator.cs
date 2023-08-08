using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SkibidiRunner.Managers
{
    public class ObjectModificator : MonoBehaviour
    {
        [SerializeField] private bool randomRotation;
        [SerializeField] private Vector3 rotationMinOffset;
        [SerializeField] private Vector3 rotationMaxOffset;
        
        [SerializeField, Space] private bool randomScale;
        [SerializeField] private Vector3 scaleMinOffset;
        [SerializeField] private Vector3 scaleMaxOffset;
        
        private void Awake()
        {
            if (randomRotation)
            {
                var offset = new Vector3
                {
                    x = Random.Range(rotationMinOffset.x, rotationMaxOffset.x),
                    y = Random.Range(rotationMinOffset.y, rotationMaxOffset.y),
                    z = Random.Range(rotationMinOffset.z, rotationMaxOffset.z)
                };
                transform.rotation = Quaternion.Euler(offset);
            }
            
            if (randomScale)
            {
                var offset = new Vector3
                {
                    x = Random.Range(scaleMinOffset.x, scaleMaxOffset.x),
                    y = Random.Range(scaleMinOffset.y, scaleMaxOffset.y),
                    z = Random.Range(scaleMinOffset.z, scaleMaxOffset.z)
                };
                transform.localScale = offset;
            }
        }
    }
}