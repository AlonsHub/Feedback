﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PatientCreationSpace
{

    [System.Serializable]
    public class Medicine : Treatment
    {

        public string medicineName; //with or without dosage (for display purposes only)
                                    //Currently dosage is part of the unique ID, so basically 10mg of drug X


        //[SerializeField]
        //string TEMP_patientDataString; //PLACEHOLDER FOR PatientMeasurementData
        public PatientMeasurements measurements;

        //Medicine Setter TBF (also a creator? I dont think so)
        public void Init(string medNAme, PatientMeasurements newMeasurements) //temp! TBF //working on it
        {
            medicineName = medNAme;
            measurements = newMeasurements;
        }
        public override object Result()
        {
            //return patientData;
            return measurements;
        }
        public override string DisplayStringAsPartOfSequence()
        {
            return $"שם התרופה:{medicineName} \n תגובה לתרופה:{measurements}";
        }
        public override string TreatmentDisplayNameAsPartOfDatabase()
        {
            return medicineName;
        }
    }

}