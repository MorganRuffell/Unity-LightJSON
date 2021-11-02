using System;
using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "JSON Objects/Player/Core", order = 0)]
    public class PlayerScriptableObject : BaseScriptableObject, IScriptableObject, IComparable
    {
        [Header("Instance Data")] public int IdNumber;

        [Header("Cameras")]
        public Camera[] MainCamera;
        public Camera[] WeaponCamera;

        [Header("Control Settings")]
        public float MouseSensitivity = 100.0f;
        public float PlayerSpeed = 5.0f;
        public float RunningSpeed = 7.0f;
        public float JumpSpeed = 5.0f;

        [Header("Audio")]
        public RandomPlayer FootstepPlayer;
        public List<AudioClip> JumpingAudioCLip;
        public List<AudioClip> LandingAudioClip;

        [Header("Character Controller")]
        public float min_moveDistance;


        List<Weapon> m_Weapons = new List<Weapon>();
        Dictionary<int, int> m_AmmoInventory = new Dictionary<int, int>();


        void IScriptableObject.FromExternal(JsonObject jsonData)
        {
            throw new System.NotImplementedException();
        }

        JsonObject IScriptableObject.ToExternal()
        {
            throw new System.NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            dynamic Object = obj as PlayerScriptableObject;

            if (IdNumber > Object.IdNumber)
            {
                return 1;
            }

            if (IdNumber < Object.IdNumber)
            {
                return -1;
            }

            else
            {
                return 0;
            }

            return 0;
        }
    }

}
