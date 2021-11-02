using LightJson;
using System;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public enum PlayerControllerType
    {
        Default = 0,
        Exotic = 1,
        Experimental = 2
    }

    [CreateAssetMenu(fileName = "Player Controller Data", menuName = "JSON Objects/Player/Controller", order = 2)]
    public class PlayerControllerScriptableObject : PlayerScriptableObject
    {
        private PlayerControllerType controllerType;

        public float SlopeLimit = 45.0f;
        public float StepOffset = 0.3f;
        public float SkinWidth = 0.08f;
        public Vector3 Center = Vector3.zero;
        public float Radius = 0.5f;
        public float Height = 1.75f;

        void FromExternal(JsonObject jsonData)
        {
            Height = jsonData["Height"].AsFloat;
            Radius = jsonData["Radius"].AsFloat;
            SlopeLimit = jsonData["SlopeLimit"].AsFloat;
            StepOffset = jsonData["StepOffset"].AsFloat;
            SkinWidth = jsonData["SkinWidth"].AsFloat;
        }

        JsonObject ToExternal()
        {
            JsonObject playerControllerJsonObject = new JsonObject
            {
                {"SlopeLimit", SlopeLimit},
                {"StepOffset", StepOffset},
                {"SkinWidth", SkinWidth},
                {"Radius", Radius},
                {"Height", Height},
            };

            return playerControllerJsonObject;
        }

        //New as we are overriding the interface implementation in the parent class.
        public new int CompareTo(object obj)
        {
            dynamic lemons = obj as PlayerControllerScriptableObject;

            return controllerType switch
            {
                PlayerControllerType.Default => 1,
                PlayerControllerType.Exotic => -1,
                PlayerControllerType.Experimental => 0,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}

