using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// This is the base for several static scripts which will allow for easy ScriptableObject creation, during runtime
/// T being the type:ScriptableObject to create
/// </summary>
/// <typeparam name="T"></typeparam>
public static class SO_Creator<T> where T : ScriptableObject
{
    static readonly string scriptableObjects_FolderPath = "Assets/Scriptables/Patients/";
    /// <summary>
    /// NO SLAHES!
    /// </summary>
    //static string subFolderName;

    /// <summary>
    /// Creates a T SO in a designated folder
    /// </summary>
    /// <param name="newID"></param>
    /// <returns></returns>
    public static T CreateT(string newID, string partialPath) 
    {
        T t = ScriptableObject.CreateInstance<T>();
        
        //AssetDatabase.CreateAsset(t, $"{scriptableObjects_FolderPath}/{subFolderName}/{nameof(T)}_{newID}.asset");
        //AssetDatabase.CreateAsset(t, $"{scriptableObjects_FolderPath}{t.GetType()}s/{newID}_{t.GetType()}.asset");
        if (!System.IO.Directory.Exists($"{scriptableObjects_FolderPath}{partialPath}"))
        {
            System.IO.Directory.CreateDirectory($"{scriptableObjects_FolderPath}{partialPath}");
        }
            AssetDatabase.CreateAsset(t, $"{scriptableObjects_FolderPath}{partialPath}/{newID}_{t.GetType()}.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        //else
        //{
        //    AssetDatabase.CreateAsset(t, $"{scriptableObjects_FolderPath}Patients/{newID}/{newID}_{t.GetType()}.asset");
        //}
        return t;
    }
}
