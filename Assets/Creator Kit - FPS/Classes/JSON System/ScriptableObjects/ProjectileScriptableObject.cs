using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Projectile data", menuName = "JSON Objects/Projectile", order = 0)]
    public class ProjectileScriptableObject : BaseScriptableObject, IScriptableObject
    {
        public bool DestroyedOnHit = true;
        public float TimeToDestroyed = 4.0f;
        public float ReachRadius = 5.0f;
        public float damage = 10.0f;
        public AudioClip DestroyedSound;


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