using System;
using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{

    [System.Serializable]
    public enum Antialiasing
    {
        None = 0,
        FastApproximateAntialiasing = 1,
        SubpixelMorphologicalAntialiasing = 2,
        TemporalAntialiasing = 3
    }

    [System.Serializable]
    public class DefferedFogAttributes
    {
        public bool Enabled;
        public bool ExcludeSkybox;
    }

    [CreateAssetMenu(fileName = "Post Process Layer Data", menuName = "JSON Objects/Effects/PostProcessLayer", order = 0)]
    public class EffectsScriptableObject : BaseScriptableObject, IScriptableObject
    {
        [Header("Antialiasing Settings")]
        public Antialiasing antialiasing;
        public DefferedFogAttributes defferedFogAttributes;

        public bool stopNaNPropagation;
        public bool finalBlitToCameraTarget;

        public void FromExternal(JsonObject jsonData, JsonObject defferedAttr)
        {
            stopNaNPropagation = jsonData["StopNanPropogation"].AsBoolean;
            finalBlitToCameraTarget = jsonData["finalBlitToCameraTarget"].AsBoolean;
            defferedFogAttributes = defferedAttr["FogAttr"].AsObject as DefferedFogAttributes;
        }

        public void FromExternal(JsonObject jsonData)
        {
            Console.WriteLine("You've callled the wrong FromExternal");
        }

        public JsonObject ToExternal()
        {
            JsonObject jsonObject = new JsonObject
            {
                { "StopNanPropogation", stopNaNPropagation },
                { "finalBlitToCameraTarget", finalBlitToCameraTarget },
                { "FogAttr", defferedFogAttributes}
            };

            return jsonObject;
        }
    }
}
