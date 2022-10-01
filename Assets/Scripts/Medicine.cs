using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Medicine : Treatment
{
    
    public string medicineName; //with or without dosage (for display purposes only)
    //Currently dosage is part of the unique ID, so basically 10mg of drug X

  
    [SerializeField]
    string TEMP_patientDataString; //PLACEHOLDER FOR PatientMeasurementData

    //Medicine Setter TBF (also a creator? I dont think so)
    public void Init(string medNAme, string newDAta) //temp! TBF //working on it
    {
        medicineName = medNAme;
        TEMP_patientDataString = newDAta;
    }
    public override object Result()
    {
        //return patientData;
        return TEMP_patientDataString;
    }
    public override string DisplayStringAsPartOfSequence()
    {
        return $"שם התרופה:{medicineName} \n תגובה לתרופה:{TEMP_patientDataString}";
    }
    public override string TreatmentDisplayNameAsPartOfDatabase()
    {
        return medicineName;                    
    }
}
