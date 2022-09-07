using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewPatientWindow : MonoBehaviour
{
    [SerializeField]
    TMP_Text patient_name;
    [SerializeField]
    TMP_Text patient_age;

    Patient patient;
    //TreatmeantSequence treatmeantSequence =>patient. //Get treatment sequence

    public void ClickOnCreateNew()
    {
        if (string.IsNullOrEmpty(patient_name.text) || string.IsNullOrEmpty(patient_age.text))
        {
            Debug.LogError("both patient_name and patient_age needs to be added");
            return;
        }

        patient = PatientCreator.CreatePatient($"q_{System.DateTime.Now.ToString("h-m")}", patient_name.text, patient_age.text);

        //continue work on setting the patient and filling their Treatment Sequence
    }

}

