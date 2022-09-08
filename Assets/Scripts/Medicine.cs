using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class Medicine : Treatment
{
    [SerializeField]
    string medicineName; //with or without dosage (for display purposes only)
    //Currently dosage is part of the unique ID, so basically 10mg of drug X
    [SerializeField]
    object patientData;

    //Medicine Setter TBF (also a creator? I dont think so)

    public override object Result()
    {
        return patientData;
    }
    public override string DisplayStringAsPartOfSequence()
    {
        return $"שם התרופה:{medicineName}";
    }
    public override string TreatmentDisplayNameAsPartOfDatabase()
    {
        return medicineName;
    }
}
