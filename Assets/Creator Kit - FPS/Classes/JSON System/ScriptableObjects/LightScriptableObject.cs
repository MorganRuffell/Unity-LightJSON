using System;
using LightJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{

    public enum LightType
    {
        Point = 0,
        Spot = 1,
        Directional = 2,
        Area = 3
    }


    [CreateAssetMenu(fileName = "Light Data", menuName = "JSON Objects/Effects/Lights", order = 3)]
    public class LightScriptableObject : ScriptableObject, IScriptableObject, IComparable
    {
        [SerializeField]
        private LightType TypeOfLight;

        public bool useViewFrustumForShadowCasterCull;
        public int shadowCustomResolution;
        public float shadowBias;
        public float shadowNormalBias;
        public float intensity;
        public float spotAngle;
        public float bounceIntensity;

        public void FromExternal(JsonObject jsonData)
        {
            useViewFrustumForShadowCasterCull = jsonData["useViewFrustumForShadowCasterCull"].AsBoolean;
            shadowCustomResolution = jsonData["shadowCustomResolution"].AsInteger;
            shadowBias = jsonData["shadowBias"].AsFloat;
            shadowNormalBias = jsonData["shadowNormalBias"].AsFloat;
            intensity = jsonData["intensity"].AsFloat;
            spotAngle =  jsonData["spotAngle"].AsFloat;
            bounceIntensity = jsonData["bounceIntensity"].AsFloat;
        }

        public JsonObject ToExternal()
        {
            JsonObject LightJsonData = new JsonObject
            {
                {"useViewFrustumForShadowCasterCull",useViewFrustumForShadowCasterCull},
                {"shadowCustomResolution", shadowCustomResolution},
                {"shadowBias", shadowBias},
                {"shadowNormalBias", shadowNormalBias},
                {"intensity", intensity},
                {"spotAngle", spotAngle},
                {"BounceIntensity",bounceIntensity}
            };

            return LightJsonData;
        }

        public int CompareTo(object obj)
        {
            dynamic LightObject = obj as LightScriptableObject;

            return LightObject.TypeOfLight switch
            {
                LightType.Point => 2,
                LightType.Spot => 1,
                LightType.Directional=> 0,
                LightType.Area => -1,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

}
