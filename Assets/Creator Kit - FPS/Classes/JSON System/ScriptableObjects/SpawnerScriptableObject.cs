using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [System.Serializable]
    public class SpawnEvent
    {
        public GameObject targetToSpawn;
        public int count;
        public float timeBetweenSpawn;
    }

    [System.Serializable]
    public class SpawnQueueElement
    {
        public GameObject obj;
        public Target target;
        public Rigidbody rb;
        public float remainingTime;
        public PathSystem.PathData pathData = new PathSystem.PathData();
    }

    [CreateAssetMenu(fileName = "Spawner Data", menuName = "JSON Objects/Spawner", order = 4)]
    public class SpawnerScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public SpawnEvent spawnEvent;
        public SpawnQueueElement spawnQueue;

        public float speed = 1.0f;


        public void FromExternal(JsonObject jsonData)
        {
            throw new System.NotImplementedException();
        }

        public JsonObject ToExternal()
        {
            throw new System.NotImplementedException();
        }
    }
}
