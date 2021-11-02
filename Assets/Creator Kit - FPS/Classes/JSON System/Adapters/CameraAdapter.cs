using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdapter : MonoBehaviour
{
    [Header("Cameras")]
    public Camera MainCamera;
    public Camera SecondaryCamera;

    public List<CameraScriptableObject> ScriptableObjects = new List<CameraScriptableObject>();

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
