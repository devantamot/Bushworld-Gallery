using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DebugManager : MonoBehaviour {

    public static string filename = "DebugLog_";
    public static string filePath = @"C:\Users\tamot\OneDrive\Documents\UMD\FIRE270\Gallery Stuff\Bushworld-Gallery\Bushworld Gallery\DebugLogs\";
    public static bool debuggerOn = false;

    // Use this for initialization
    void Start () {
        if (debuggerOn)
        {
            filename += (System.DateTime.Now + "").Replace("/", "-") + ".txt";
            filename = filename.Replace(" ", "_");
            filename = filename.Replace(":", "-");
            Debug.Log((System.DateTime.Now + "").Replace("\\", "-"));
            System.IO.File.WriteAllText(filePath + filename, "DubugManager Initalized\n");
        }

    }

    //Write to C:\Users\tamot\OneDrive\Documents\UMD\FIRE270\Gallery Stuff\Bushworld-Gallery\Bushworld Gallery\DebugLogs\
    public static void Log(string message)
    {
        if (debuggerOn)
        {
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(filePath + filename, true))
            {
                file.WriteLine("\n" + message);
            }

        }
    }
}
