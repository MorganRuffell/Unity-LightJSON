using LightJson;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace ScriptableObjects
{
    public enum PointsValue
    {
        Five = 5,
        Ten = 10,
        Thirty = 30,
        Sixty = 60,
        Ninty = 90,
    }

    #region EffectValues

    [System.Serializable]
    public class PlayerHitAttributes
    {
        float HitPlayerSoundPitch;
    }

    [System.Serializable]
    public class LimitsToVelocityOverlifetime
    {
        public bool enabled;
        public float limitXMultiplier;
        public float limitYMultiplier;
        public float limitZMultiplier;
        public float limitMultiplier;
    }

    [System.Serializable]
    public class InheritVelocityModule
    {
        public MinMaxCurve curve;
    }

    [System.Serializable]
    public class SizeOverLifetimeModule
    {
        public bool enabled;
        public MinMaxCurve size;
        public float sizeMultiplier;
        public MinMaxCurve x;
        public float xMultiplier;
        public MinMaxCurve y;
        public float yMultiplier;
        public MinMaxCurve z;
        public float zMultiplier;
        public bool separateAxes;
    }

    [System.Serializable]
    public class EffectValues
    {
        public float time;
        public bool enabled;
    }

    #endregion


    [CreateAssetMenu(fileName = "Enemy Data", menuName = "JSON Objects/Enemy/Core", order = 0)]
    public class EnemyScriptableObject : BaseScriptableObject, IScriptableObject, IComparable
    {
        public float MaxHealth = 6.0f;
        public PointsValue pointsValue;
        public int IndexOfListToUse;

        public List<ParticleSystem> DestroyedEffects;

        [Header("Audio")]
        public RandomPlayer HitPlayer;
        public AudioSource IdleSource;

        public EffectValues _EffectValues;
        public SizeOverLifetimeModule sizeOverLifetimeModule;
        public InheritVelocityModule inheritVelocityModule;
        public LimitsToVelocityOverlifetime limitsToVelocityOverlifetimeModule;
        public PlayerHitAttributes playerHitAttributes;


        public int CompareTo(object obj)
        {
            dynamic EnemyObject = obj as EnemyScriptableObject;

            return EnemyObject.pointsValue switch
            {
                PointsValue.Five => 10,
                PointsValue.Ten => 9,
                PointsValue.Thirty => 8,
                PointsValue.Sixty => 7,
                PointsValue.Ninty => 6,
                _ => 0
            };
        }

        public void Awake()
        {
        }

        public void FromExternal(JsonObject jsonData)
        {
            IndexOfListToUse = jsonData["IndexOfListToUse"].AsInteger;


            _EffectValues.time = (float) jsonData["EffectValues_Time"].AsNumber;
            _EffectValues.enabled = jsonData["EffectValues_Enabled"].AsBoolean;

            sizeOverLifetimeModule.xMultiplier = (float) jsonData["SizeOverLifetimeModule_x"].AsNumber;
            sizeOverLifetimeModule.yMultiplier = (float) jsonData["SizeOverLifetimeModule_y"].AsNumber;
            sizeOverLifetimeModule.zMultiplier = (float) jsonData["SizeOverLifetimeModule_z"].AsNumber;

            MaxHealth = (float) jsonData["MaxHealth"].AsNumber;

            //Fetch this as a jsonObject?
            pointsValue = jsonData["PointsValue"].AsString;
        }
        
        public JsonObject ToExternal()
        {
            JsonObject jsonData = new JsonObject
            {
                {"IndexOfListToUse", IndexOfListToUse},
                {"EffectValues_Time", _EffectValues.time},
                {"EffectValues_Enabled", _EffectValues.enabled },

                {"SizeOverLifetimeModule_x", sizeOverLifetimeModule.xMultiplier },
                {"SizeOverLifetimeModule_y", sizeOverLifetimeModule.yMultiplier },
                {"SizeOverLifetimeModule_z", sizeOverLifetimeModule.zMultiplier },

                {"MaxHealth", MaxHealth},


                {"PointsValue" , pointsValue == PointsValue.Five}
            };

            return jsonData;
        }

        
    }

}
