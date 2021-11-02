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
        isGlobal = jsonData["isGlobal"].AsBoolean;
        priority = jsonData["priority"].AsFloat;
        weight = jsonData["weight"].AsFloat;
        blendDistance = jsonData["blendDistance"].AsFloat;
    }

    public JsonObject ToExternal()
    {
        JsonObject ppVolumeDataJsonObject = new JsonObject
        {
            {"isGlobal",isGlobal},
            {"priority",priority},
            {"weight",weight},
            {"blendDistance",blendDistance},
        };

        return ppVolumeDataJsonObject;
    }
}
