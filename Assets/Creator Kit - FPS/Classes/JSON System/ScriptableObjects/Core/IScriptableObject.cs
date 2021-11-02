using System.Collections;
using LightJson;
using System.Collections.Generic;
using UnityEngine;

public interface IScriptableObject 
{
    public void FromExternal(JsonObject jsonData);

    public JsonObject ToExternal();
}
