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

    Patient createdPatient;
    //TreatmeantSequence treatmeantSequence =>patient. //Get treatment sequence
    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;


    public void ClickOnCreateNew()
    {
        if (string.IsNullOrEmpty(patient_name.text) || string.IsNullOrEmpty(patient_age.text))
        {
            Debug.LogError("both patient_name and patient_age needs to be added");
            return;
        }

        createdPatient = PatientCreator.CreatePatient($"p_{System.DateTime.Now.ToString("h-m")}", patient_name.text, patient_age.text);

        treatmentSequenceEditorWindow.gameObject.SetActive(true);
        treatmentSequenceEditorWindow.Init(createdPatient);
        //continue work on setting the patient and filling their Treatment Sequence
    }

    //cancel patient creation - delete all SOs that need to be deleted (keep questions, because why not?)

}

