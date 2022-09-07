using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class QuestionCreator
{
    //TBF - create a static class to hold all paths
    static readonly string scriptableObjects_FolderPath = "Assets/Scriptables/Questions/";

    public static Question CreateQuestion(string newID, string newQuestion, string newAnswer)
    {
        //Question q = ScriptableObject.CreateInstance<Question>();
        Question q = SO_Creator<Question>.CreateT(newID);
        q.SetQuestion(newID, newQuestion, newAnswer);

        //AssetDatabase.CreateAsset(q, $"{scriptableObjects_FolderPath}question_{newID}.asset");
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
        return q;
    }
}
