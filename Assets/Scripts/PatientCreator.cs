﻿using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public static class PatientCreator 
{
    static readonly string scriptableObjects_FolderPath = "Assets/Scriptables/Patients/";
    public static string patientID => currentPatient.id;
    public static Patient currentPatient;
    public static NewPatientData newPatient;
    /// <summary>
    /// DEPRECATED!
    /// </summary>
    /// <param name="newID"></param>
    /// <param name="patientName"></param>
    /// <param name="age"></param>
    /// <returns></returns>
    //public static Patient CreatePatient(string newID, string patientName, string age)
    //{
    //    currentPatient= new Patient();

    //    //set patient TBF
    //    currentPatient.Init(newID, patientName, age);
        
    //    //create file already?


    //    return currentPatient;
    //}
    public static NewPatientData CreateNewPatient(string name, string sureName, int id, int age, string gender, string phoneNum, string medicalCompany, string adress, string complaint, string[] measurements)
    {
        newPatient= new NewPatientData();

        //set patient TBF
        newPatient.Initialize(name, sureName, id, age, gender, phoneNum, medicalCompany, adress, complaint, measurements);
        
        //create file already?


        return newPatient;
    }

    public static bool SaveCurrentPatient()
    {
        if(currentPatient == null)
        {
            Debug.LogError("no current patient!");
            return false;
        }

        string patientJSON = JsonUtility.ToJson(currentPatient);
        if (!Directory.Exists($"{scriptableObjects_FolderPath}"))
        {
            Directory.CreateDirectory($"{scriptableObjects_FolderPath}");
        }
        StreamWriter sw= File.CreateText($"{scriptableObjects_FolderPath}/{currentPatient.paitent_name}.txt");

        sw.Write(patientJSON);
        sw.Close();

        string treatmentSequence = SerializeTreatmentSequence(currentPatient.GetTreatmeantSequence);

        StreamWriter sw2 = File.CreateText($"{scriptableObjects_FolderPath}/{currentPatient.paitent_name}_treatmentSequence.txt");

        sw2.Write(treatmentSequence);
        sw2.Close();


        return true; //successful save!
    }
    public static bool SaveNewPatient()
    {
        if(newPatient == null)
        {
            Debug.LogError("no new patient!");
            return false;
        }

        string patientJSON = JsonUtility.ToJson(newPatient);
        if (!Directory.Exists($"{scriptableObjects_FolderPath}"))
        {
            Directory.CreateDirectory($"{scriptableObjects_FolderPath}");
        }
        StreamWriter sw= File.CreateText($"{scriptableObjects_FolderPath}/{newPatient.Name}_{newPatient.SureName}.txt");

        sw.Write(patientJSON);
        sw.Close();

        string treatmentSequence = SerializeTreatmentSequence(newPatient.FullTreatmentSequence);

        StreamWriter sw2 = File.CreateText($"{scriptableObjects_FolderPath}/{newPatient.Name}_{newPatient.SureName}_treatmentSequence.txt");

        sw2.Write(treatmentSequence);
        sw2.Close();


        return true; //successful save!
    }


    public static string SerializeTreatmentSequence(TreatmentSequence treatmentSequence)
    {
        string toReturn = "";
        foreach (var block in treatmentSequence.sequenceBlocks)
        {
            switch (block.typeString)
            {
                //case "Question":
                default:
                    toReturn += $"{block.typeString}_{JsonUtility.ToJson(block)}\n";
                    break;
                case "TreatmentGroup":
                    TreatmentGroup tg = (TreatmentGroup)block;
                    toReturn += "Start_TreatmentGroup\n";

                    foreach (var inner_block in tg.SequenceBlocks())
                    {
                        toReturn += $"{inner_block.typeString}_{JsonUtility.ToJson(inner_block)}\n";
                    }
                    toReturn += "End_TreatmentGroup\n";
                    break;
            }
        }
        TreatmentSequence tsTest = DeSerializeTreatmentSequence(toReturn);

        Debug.Log(tsTest.AllDisplayStrings());

            return toReturn;
    }

    public static TreatmentSequence DeSerializeTreatmentSequence(string serializedTreatmentSequence)
    {
        TreatmentSequence toReturn = new TreatmentSequence();
        toReturn.Init();
        TreatmentGroup tempGroup = null;

        string[] lines = serializedTreatmentSequence.Split('\n');
        foreach (var line in lines)
        {
            string[] fields = line.Split('_');
            List<string> data = fields.ToList();
            data.Remove(fields[0]);
            string datastring = string.Concat(data);
            if (tempGroup != null)
            {
                switch (fields[0])
                {
                    case "Question":
                        Question q = JsonUtility.FromJson<Question>(datastring);
                        tempGroup.AddTreatment(q);
                        break;
                    case "Test":
                        Test t = JsonUtility.FromJson<Test>(datastring);
                        tempGroup.AddTreatment(t);
                        break;
                    case "Medicine":
                        Medicine m = JsonUtility.FromJson<Medicine>(datastring);
                        tempGroup.AddTreatment(m);
                        break;
                    
                    case "End":
                        tempGroup = null;
                        break;

                    default:
                        break;
                }
            }
            else
            {

                switch (fields[0])
                {
                    case "Question":
                        Question q = JsonUtility.FromJson<Question>(datastring);
                        toReturn.AddToSequence(q);
                        break;
                    case "Test":
                        Test t = JsonUtility.FromJson<Test>(datastring);
                        toReturn.AddToSequence(t);
                        break;
                    case "Medicine":
                        Medicine m = JsonUtility.FromJson<Medicine>(datastring);
                        toReturn.AddToSequence(m);
                        break;
                    case "Start":
                        tempGroup = new TreatmentGroup();
                        tempGroup.Init();
                        toReturn.AddToSequence(tempGroup);
                        break;

                    default:
                        break;
                }
            }
        }
            return toReturn;
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
