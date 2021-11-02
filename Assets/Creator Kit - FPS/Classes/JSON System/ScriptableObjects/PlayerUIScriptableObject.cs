using LightJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player UI Data", menuName = "JSON Objects/Player/UI", order = 1)]
    public class PlayerUIScriptableObject : BaseScriptableObject, IScriptableObject
    {
        [Header("Audio Clips")]
        public List<AudioClip> PositiveSounds;
        public List<AudioClip> NegativeSounds;

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

