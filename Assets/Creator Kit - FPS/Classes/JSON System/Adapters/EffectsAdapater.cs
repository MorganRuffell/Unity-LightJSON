using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace JSONAdapters
{
    [System.Serializable]
    public class EffectsData
    {
        [Header("Effects To Control")]
        public UnityEngine.Rendering.PostProcessing.PostProcessLayer[] postProcessLayer;
        public List<PostProcessVolume> Volumes;
        public List<AudioSource> AudioSources;
    }


    public class EffectsAdapater : MonoBehaviour
    {
        public EffectsData effects;

        public List<EffectsScriptableObject> effectsScripts;
        public List<SoundScriptableObject> soundScripts;
        public List<PostProcessVolumeScriptableObject> ProcessVolumeScriptableObjects;

        public void Start()
        {

        }

        public void FixedUpdate()
        {

        }

    }
}




