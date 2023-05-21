using System.Collections.Generic;
using UnityEngine;

namespace GorillaVFX
{
    internal class ObjectPool : MonoBehaviour
    {
        private IDictionary<string, GameObject> GameObjects;
        private const int 
        private void Start()
        {
            GameObjects = new Dictionary<string, GameObject>();

            
        }
    }
}
