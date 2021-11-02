using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace JSONManagement
{
    [Serializable]
    public enum fileTypes
    {
        [Description("json file type")]
        json = 1,
        [Description("xml file type")]
        xml = 2,
        [Description("txt file type")]
        txt = 3,
        [Description("csv file type")]
        csv = 4,
    }

    public sealed class JSONManager : MonoBehaviour
    {
        #region SingletonManagement

        public static JSONManager instance = null;

        JSONManager()
        {
        }

        #endregion

        [Header("Controlling Classes")]
        public ScriptableObjectManager ObjectManager;


        [Header("JSON Read Controls")]
        public bool CanReadFromString = true;
        public bool ReadFormattedJSON = true;

        [Space(5)]

        public bool AllowReadingFromOtherDirectories = false;

        [Space(5)]

        [Header("File Operations & Paramaters")]
        public bool CanSaveToJSON = true;
        public bool WriteLocally = true;
        public bool ReadLocally = true;

        public string FileName = "ScriptableObjectData";

        [Header("File Type Paramaters")]
        public string FileLocation = "";
        public string File = "";
        public fileTypes fileType;

        private dynamic FinalFileType;

        public void awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this);
                instance = this;
            }

            else if (instance != this)
            {
                Destroy(gameObject);
            }

            try
            {
                DetermineFileType();
            }
            catch (System.Exception)
            {
                Debug.LogError("File type error!");
                return;
            }
        }

        public bool DetermineFileType()
        {
            switch (fileType)
            {
                case fileTypes.json:
                    FinalFileType = "." + fileType.ToString().ToLower();
                    return true;

                case fileTypes.xml:
                    FinalFileType = "." + fileType.ToString().ToLower();
                    return true;

                case fileTypes.txt:
                    FinalFileType = "." + fileType.ToString().ToLower();
                    return true;

                case fileTypes.csv:
                    FinalFileType = "." + fileType.ToString().ToLower();
                    return true;

                default:
                    throw new System.Exception("File types cannot be anything other than what is outlined in the enum!");
                    return false;
            }
        }

        private void OnValidate()
        {
            if (WriteLocally)
            {
                WriteLocally = false;

                if (CanSaveToJSON)
                {
                    //JSONManager.WriteObjectsToJSON();
                }
                else
                {
                    Debug.Log("You need to enable writing to JSON");
                }
            }

            if (ReadLocally)
            {
                ReadLocally = false;

                ////if (JSONManager.JSONManagerRead.CanReadFromJSON)
                //{
                //    //JSONManager.ReadObjectsFromFile();
                //}
                //else
                //{
                //    Debug.Log("You need to enable reading from JSON");
                //}
            }
        }

    }







}


