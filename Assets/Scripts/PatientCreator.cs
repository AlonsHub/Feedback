using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class PatientCreator 
{
    //static readonly string scriptableObjects_FolderPath = "Assets/Scriptables/Patients/";
    public static Patient CreatePatient(string newID, string patientName, string age)
    {
        Patient patient = SO_Creator<Patient>.CreateT(newID);

        //set patient TBF
        patient.Init(patientName, age);

        return patient;
    }
    //public static Patient CreatePatient(string newID, string patientName, string age)
    //{
    //    //Question q = ScriptableObject.CreateInstance<Question>();
    //    //q.SetQuestion(newID, newQuestion, newAnswer);
    //    Patient patient = ScriptableObject.CreateInstance<Patient>();
    //    //patient.CreateNewTreatmentSequence();

    //    AssetDatabase.CreateAsset(patient, $"{scriptableObjects_FolderPath}patient_{newID}.asset");
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();
    //    return patient;
    //}
}
