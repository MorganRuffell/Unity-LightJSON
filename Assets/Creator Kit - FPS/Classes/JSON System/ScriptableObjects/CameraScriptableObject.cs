using System;
using LightJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace ScriptableObjects
{
    [System.Serializable]
    public class ClippingPlanes
    {
        public float near = 0.3f;
        public float far = 1000;
    }

    [System.Serializable]
    public class PostProcessLayer
    {
        public bool defferedFogEnabled = true;
    }

    [System.Serializable]
    public enum CameraType
    {
        Weapon = 1,
        Player = 2
    }

    [CreateAssetMenu(fileName = "Main Camera Data", menuName = "JSON Objects/Camera", order = 0)]
    public class CameraScriptableObject : ScriptableObject, IScriptableObject, IComparable
    {
        public CameraType cameraType;
        public Camera MainCamera;
        public PostProcessLayer postProcessLayer;

        public double FOV = 60.0f;
        public int depth = -1;
        public bool UseOcclusionCulling;

        public ClippingPlanes clippingPlanes;
        public PostProcessLayer postProcess;

        public void FromExternal(JsonObject jsonData)
        {
            FOV = jsonData["FieldOfView"].AsNumber;
            depth = jsonData["Depth"].AsInteger;
            UseOcclusionCulling = jsonData["UseOcclusionCulling"].AsBoolean;
            clippingPlanes.near = (float) jsonData["NearClippingPlanes"].AsNumber;
            postProcess.defferedFogEnabled = jsonData["DefferedFogEnabled"].AsBoolean;
        }

        public JsonObject ToExternal()
        {
            JsonObject jsonData = new JsonObject
            {
                { "FieldOfView", FOV },
                { "Depth", depth },
                { "UseOcclusionCulling", UseOcclusionCulling },
                { "NearClippingPlanes", clippingPlanes.near},
                { "FarClippingPlanes", clippingPlanes.far},
                { "DefferedFogEnabled", postProcess.defferedFogEnabled}
            };

            return jsonData;
        }

        public int CompareTo(object obj)
        {
            dynamic CameraObject = obj as CameraScriptableObject;

            return CameraObject.cameraType switch
            {
                CameraType.Player => 1,
                CameraType.Weapon => -1,
                _ => 0
            };
        }

    }

}
