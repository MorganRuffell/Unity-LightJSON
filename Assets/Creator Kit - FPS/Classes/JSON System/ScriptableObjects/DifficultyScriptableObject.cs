using System;
using LightJson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace ScriptableObjects
{
    [System.Serializable]
    public enum _Difficulty
    {
        VeryEasy = 1,
        Easy = 2,
        Medium = 3,
        Hard = 4,
    }

    [CreateAssetMenu(fileName = "Difficulty Data", menuName = "JSON Objects/Difficulty", order = 2)]

    public sealed class DifficultyScriptableObject : BaseScriptableObject, IScriptableObject, IComparable
    {
        public _Difficulty Difficulty;

        public float TargetMissedPenalty = 4.0f;
        
        [Range(1,20)]
        public int TargetCount;

        [Range(5, 40)]
        public int Score;

        [Range(1, 6)]
        public float? ExperienceMultiplier = 1.1f;

        public void FromExternal(JsonObject jsonData)
        {
            TargetMissedPenalty = (float) jsonData["MissedPenalty"].AsNumber;
            TargetCount = jsonData["TargetCount"].AsInteger;
            ExperienceMultiplier = (float) jsonData["ExperienceMultiplier"].AsNumber;
            Score = jsonData["Base Score"].AsInteger;
        }

        public JsonObject ToExternal()
        {
            JsonObject jsonDifficultyData = new JsonObject
            {
                { "MissedPenalty", TargetMissedPenalty },
                { "TargetCount", TargetCount },
                {"ExperienceMultiplier", ExperienceMultiplier},
                {"Base Score", Score}
            };
            
            return jsonDifficultyData;
        }

        public int CompareTo(object obj)
        {
            dynamic DifficultyObject = obj as DifficultyScriptableObject;

            if (Difficulty > DifficultyObject.Difficulty)
            {
                return 1;
            }
            else if (Difficulty < DifficultyObject.Difficulty)
            {
                return - 1;
            }
            else
            {
                return 0;
            }
        }
    }



}

