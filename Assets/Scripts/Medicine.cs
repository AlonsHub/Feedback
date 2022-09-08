using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class Medicine : Treatment
{
    [SerializeField]
    string medicineName; //with or without dosage (for display purposes only)
    //Currently dosage is part of the unique ID, so basically 10mg of drug X

    /// <summary>
    /// Should remain EMPTY for instances of Medcine that are in the Database.
    /// Medicine as part of a treatment sequence should have a "patientMeasurementData" instructions as how to change a patients PatientMeasurementData
    /// </summary>
    [SerializeField]
    object patientData;

    [SerializeField]
    string TEMP_patientDataString; //PLACEHOLDER FOR PatientMeasurementData

    //Medicine Setter TBF (also a creator? I dont think so)
    public void SetPatientData(string newDAta) //temp! TBF
    {
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
