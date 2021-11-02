using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public enum TriggerType
    {
        Auto,
        Manual
    }

    public enum WeaponType
    {
        Raycast,
        Projectile
    }

    [System.Serializable]
    public class AdvancedSettings
    {
        public float spreadAngle = 0.0f;
        public int projectilePerShot = 1;
        public float screenShakeMultiplier = 1.0f;
    }

    [CreateAssetMenu(fileName = "Weapon Data", menuName = "JSON Objects/Weapon", order = 0)]
    public class WeaponScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public TriggerType triggerType;
        public WeaponType weaponType;

        public float DissolveEffectTime = 2.0f;
        public float speed = 2.0f;
        public int ClipSize = 10;
        public float damage = 5;

        public AdvancedSettings advancedSettings;

        [Header("Audio Clips")]
        public AudioClip[] FireAudioClip;
        public AudioClip[] ReloadAudioClip;

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
