using System;
using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Animation data", menuName = "JSON Objects/Enemy/Animator", order = 1)]
    public class EnemyAnimatorScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public float gravityWeight;
        public float playbackTime;
        public float speed;
        public bool animatePhysics;
        public bool applyRootMotion;

        public void FromExternal(JsonObject jsonData)
        {
            gravityWeight = (float) jsonData["GravityWeight"].AsNumber;
            playbackTime = (float) jsonData["PlaybackTime"].AsNumber;
            speed = (float) jsonData["AnimationPlaybackSpeed"].AsNumber;

            animatePhysics = jsonData["DoAnimatePhysics"].AsBoolean;
            applyRootMotion = jsonData["DoApplyRootMotion"].AsBoolean;
        }
        public JsonObject ToExternal()
        {
            JsonObject jsonData = new JsonObject
            {
                {"GravityWeight", gravityWeight},
                {"PlaybackTime", playbackTime},
                {"speed", speed},
                {"DoAnimatePhysics", animatePhysics},
                {"DoApplyRootMotion", applyRootMotion}
            };

            return jsonData;
        }
    }
}
