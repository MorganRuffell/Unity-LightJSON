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

        [SerializeField] private int indexOfPositiveSoundsToPlay = 0;
        [SerializeField] private int indexOfNegativeSoundsToPlay = 0;


        public void FromExternal(JsonObject jsonData)
        {
            indexOfPositiveSoundsToPlay = jsonData["indexOfPositiveSoundsToPlay"].AsInteger;
            indexOfNegativeSoundsToPlay = jsonData["indexOfNegativeSoundsToPlay"].AsInteger;
        }

        public JsonObject ToExternal()
        {
            JsonObject indexJsonObject = new JsonObject
            {
                {"indexOfPositiveSoundsToPlay", indexOfPositiveSoundsToPlay},
                {"indexOfNegativeSoundsToPlay", indexOfNegativeSoundsToPlay},
            };

            return indexJsonObject;
        }
    }

}

