using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewPatientWindow : MonoBehaviour
{
    [Header("Bsaic Info Input Fields")]
    [SerializeField]
     TMP_Text Name;
    [SerializeField]
     TMP_Text SureName;
    [SerializeField]
     TMP_Text Id, Age;
    [SerializeField]
     TMP_Text Gender;
    [SerializeField]
     TMP_Text PhoneNumber;
    [SerializeField]
     TMP_Text MedicalCompany, AddressLocation, Complaint;
    //[Header("Measurement Input Fields")]
    //[SerializeField]
    //TMP_Text BPM_InputField;
    //[SerializeField]
    //TMP_Text PainLevel_InputField;
    //[SerializeField]
    //TMP_Text RespiratoryRate_InputField;
    //[SerializeField]
    //TMP_Text CincinnatiLevel_InputField;
    //[SerializeField]
    //TMP_Text BloodSugar_InputField;
    //[SerializeField]
    //TMP_Text BloodPressure_InputField;
    //[SerializeField]
    //TMP_Text OxygenSaturation_InputField;
    //[SerializeField]
    //TMP_Text ETCO2_InputField;
    //[SerializeField]
    //TMP_Text AdditionalMuscles_InputField;
    //[SerializeField]
    //TMP_Text Breathing_InputField;
    //[SerializeField]
    //TMP_Text BreathingSounds_InputField;
    //[SerializeField]
    //TMP_Text Speakability_InputField;
    //[SerializeField]
    //TMP_Text Consciousness_InputField;
    //[SerializeField]
    //TMP_Text Pupils_InputField;
    //[SerializeField]
    //TMP_Text SkinState_InputField;

    [SerializeField]
    List<TMP_Text> measurementInputFields;
    

    Patient createdPatient;
    
    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;


    public void ClickOnCreateNew()
    {
        //check are REQUIRED(?) fields TBD

        //if (string.IsNullOrEmpty(patient_name.text) || string.IsNullOrEmpty(patient_age.text))
        //{
        //    Debug.LogError("both patient_name and patient_age needs to be added");
        //    return;
        //}

        PatientMeasurements patientMeasurements = new PatientMeasurements();

        string[] measurementArray = new string[System.Enum.GetValues(typeof(Measurements)).Length];
        for (int i = 0; i < measurementInputFields.Count; i++)
        {
            measurementArray[i] = measurementInputFields[i].text;
        }
        patientMeasurements.Initialize(measurementArray);
   

        //get unique ID placeholder - TBD
        string s = System.DateTime.Now.ToString("m-s");
        //createdPatient = PatientCreator.CreatePatient(s, patient_name.text, patient_age.text);

        //createdPatient.Init(s, patient_name.text, patient_age.text);
        treatmentSequenceEditorWindow.gameObject.SetActive(true);
        treatmentSequenceEditorWindow.Init(createdPatient);
        //continue work on setting the patient and filling their Treatment Sequence
    }
    public void SavePatient()
    {
        PatientCreator.SaveCurrentPatient();
    }
    //cancel patient creation - delete all SOs that need to be deleted (keep questions, because why not?)
    public void CancelPatientCreation()
    {
        if(createdPatient == null)
        {
            Debug.LogError("no patient to cancel!");
            return;
        }    
    }
}

