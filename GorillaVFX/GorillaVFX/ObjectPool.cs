using System.Collections.Generic;
using UnityEngine;

namespace GorillaVFX
{
    internal class ObjectPool : MonoBehaviour
    {
        private static ObjectPool _instance; // Makes this a singleton
        public static ObjectPool Instance { get { return _instance; } }

        private List<GameObject> pool;
        private int poolLimit;

        void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(_instance);
            else
                _instance = this;
        }

        void Start() // This is mostly just to show how it would work. We could add more pools to different types of particle effects that get used a lot
        {
            pool = new List<GameObject>();

            GameObject tmp;
            for (int i = 0; i < poolLimit; i++)
            {
                tmp = Util.ParticleCreator.Basic3DParticle(
                    Util.ParticleCreator.getMesh(PrimitiveType.Sphere),
                    ParticleSystemShapeType.Sphere,
                    true,
                    1,
                    5,
                    1,
                    0.3f,
                    1,
                    20,
                    100,
                    Color.red);
                tmp.SetActive(false);
                pool.Add(tmp);
            }
        }

        public GameObject GetPoolObj()
        {
            for (int i = 0; i < poolLimit; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }
            }
            return null;
        }
    }
}
