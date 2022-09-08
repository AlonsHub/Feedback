using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu()]
public class Patient : ScriptableObject
{
    //patient ID card
    //temp id TBF - needs to be it's own struct of all ID card info
    [SerializeField]
    string paitent_name;
    [SerializeField]
    string paitent_age;
    //patientData - measurements 
    //temp data TBF - needs to be the patientMeasurement class from the project
    object patientData;


    //Treatment sequence!
    [SerializeField]//?
    TreatmeantSequence paitent_FullTreatmentSequence;
    public TreatmeantSequence GetTreatmeantSequence { get=> paitent_FullTreatmentSequence; }

    //public SequenceBlock SequenceBlock(int i) => 

    public void Init(string newName, string newAge)
    {
        paitent_name = newName;
        paitent_age = newAge;
        CreateNewTreatmentSequence();
    }
    private void CreateNewTreatmentSequence()
    {
        //paitent_FullTreatmentSequence = CreateInstance<TreatmeantSequence>();
        paitent_FullTreatmentSequence = SO_Creator<TreatmeantSequence>.CreateT($"{paitent_name}TS");
        paitent_FullTreatmentSequence.Init();
    }

    //public void AddToTreatmentSequence(SequenceBlock sequenceBlock)
    //{

    //}

}
