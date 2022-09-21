using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class QuestionCreator
{
    //TBF - create a static class to hold all paths
    //static readonly string scriptableObjects_FolderPath = "Assets/Scriptables/Questions/";

    public static Question CreateQuestion(string newID, string newQuestion, string newAnswer)
    {
        ////temp
        //if (!System.IO.Directory.Exists($"Assets/Scriptables/Patients/{newID}/Questions/"))
        //{
        //    System.IO.Directory.CreateDirectory($"Assets/Scriptables/Patients/{newID}/Questions/");
        //}
        Question q = SO_Creator<Question>.CreateT(newID, $"{PatientCreator.patientID}/Questions/");
        q.SetQuestion(newID, newQuestion, newAnswer);

        //TBF add to database!
        
        return q;
    }
}
