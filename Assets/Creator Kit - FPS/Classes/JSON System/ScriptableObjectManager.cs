using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSONManagement
{
    [System.Serializable]
    public class EffectObjects
    {
        [Header("Audio Objects")]
        public SoundScriptableObject[] SoundScriptableObjects;

        [Header("Effects Objects")]
        public EffectsScriptableObject[] PostProcessEffects;
        public PostProcessVolumeScriptableObject[] PostProcessVolumeScriptableObjects;
        public LightScriptableObject[] LightScriptableObjects;   
    }


    [System.Serializable]
    public class GameplayObjects
    {
        [Header("CameraObjects")]
        public List<CameraScriptableObject> cameraScriptableObjects;

        [Header("Enemy Objects")]
        public List<EnemyScriptableObject> enemyScriptableObjects;
        public EnemyAnimatorScriptableObject[] enemyAnimatorScriptableObjects;

        [Header("Player Objects")]
        public PlayerControllerScriptableObject[] playerControllerScriptableObjects;
        public PlayerScriptableObject[] playerScriptableObjects;
        public PlayerUIScriptableObject[] playerUIScriptableObjects;
        public PlayerUIAudioScriptableObject[] playerUIAudioScriptableObjects;
        public WeaponScriptableObject[] weaponScriptableObjects;

        [Header("Projectile Objects")]
        public ProjectileScriptableObject[] projectileScriptableObjects;

        [Header("Spawner & System Objects")]
        public SpawnerScriptableObject[] spawnerScriptableObjects;
        public SystemScriptableObject[] SystemScriptableObjects;
        public List<DifficultyScriptableObject> difficultyScriptableObjects;
    }

    public sealed class ScriptableObjectManager : MonoBehaviour
    {
        public JSONManager _JSONManager;

        public GameplayObjects GameplayObjects;
        public EffectObjects EffectObject;

        public void Awake()
        {
            //We will sort scriptable objects based on local variables, this is case dependent. Because they all implement IComparable
            GameplayObjects.enemyScriptableObjects.Sort();
            GameplayObjects.difficultyScriptableObjects.Sort();
            GameplayObjects.cameraScriptableObjects.Sort();
        }


    }

}

