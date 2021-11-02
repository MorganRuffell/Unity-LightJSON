using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Audio Data", menuName = "JSON Objects/Effects/Audio Source", order = 1)]

    public class SoundScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public bool Mute = false;
        public bool BypassEffects = false;
        public bool BypassReverbZones = false;
        public bool PlayOnAwake = true;
        public bool Loop = true;

        [Header("Volumes & Spatial Control")]
        public float minVolume;
        public float maxVolume;
        public float pitch;
        public float volume;
        public float pan;
        public float panLevel;


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

