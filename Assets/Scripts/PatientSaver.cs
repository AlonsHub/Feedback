using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class PatientJSON
{
    // Patient data fields
    //patient ID card
    //temp id TBF - needs to be it's own struct of all ID card info
    public string id;
    [SerializeField]
    public string paitent_name;
    [SerializeField]
    public string paitent_age;
    //patientData - measurements 
    //temp data TBF - needs to be the patientMeasurement class from the project
    public string measurements;


    public TreatmentSequence treatmentSequence;
}
