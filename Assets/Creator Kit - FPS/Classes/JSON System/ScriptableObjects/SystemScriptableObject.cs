using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "System Data", menuName = "JSON Objects/System", order = 3)]
    public class SystemScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public float TargetMissedPenalty = 1.0f;
        public List<AudioClip> EndGameSounds;


        void IScriptableObject.FromExternal(JsonObject jsonData)
        {
            throw new System.NotImplementedException();
        }

        JsonObject IScriptableObject.ToExternal()
        {
            throw new System.NotImplementedException();
        }

    }
}
