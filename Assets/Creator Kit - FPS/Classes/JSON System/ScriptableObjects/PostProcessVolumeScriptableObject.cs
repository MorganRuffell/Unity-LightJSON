using LightJson;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Post Process Volume Data", menuName = "JSON Objects/Effects/PostProcessVolume", order = 2)]
public class PostProcessVolumeScriptableObject : BaseScriptableObject, IScriptableObject
{
    public bool isGlobal;
    public float priority;
    public float weight;
    public float blendDistance;

    public void FromExternal(JsonObject jsonData)
    {
        throw new System.NotImplementedException();
    }

    public JsonObject ToExternal()
    {
        throw new System.NotImplementedException();
    }
}
