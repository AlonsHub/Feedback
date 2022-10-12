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
    

    [SerializeField]
    List<TMP_Text> measurementInputFields;
    

    Patient createdPatient;
    NewPatientData newCreatedPatient;
    
    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;


    public void ClickOnCreateNew()
    {
        //check are REQUIRED(?) fields TBD

        //Basic info nullorempty checks:
        if (string.IsNullOrEmpty(Name.text) || string.IsNullOrEmpty(SureName.text) || 
            string.IsNullOrEmpty(Age.text) || string.IsNullOrEmpty(Gender.text)
             || string.IsNullOrEmpty(PhoneNumber.text) || string.IsNullOrEmpty(MedicalCompany.text)
              || string.IsNullOrEmpty(AddressLocation.text) || string.IsNullOrEmpty(Complaint.text))
        {
            Debug.LogError("all basic info fields need to be filled!");
            return;
        }
        //Initial Measurements nullorempty checks: in the grabbing bleow
        
        PatientMeasurements patientMeasurements = new PatientMeasurements();

        string[] measurementArray = new string[System.Enum.GetValues(typeof(Measurements)).Length];
        for (int i = 0; i < measurementInputFields.Count; i++)
        {
            if(string.IsNullOrEmpty(measurementInputFields[i].text)) //Initial Measurements nullorempty checks here!
            {
                Debug.LogError("all initial measurement fields need to be filled!");

                return;
            }
            measurementArray[i] = measurementInputFields[i].text;
        }

        //patientMeasurements.Initialize(measurementArray);
   
        //Other Settings section TBD
        


        //get unique ID placeholder - TBD
        //string s = System.DateTime.Now.ToString("m-s");

        //createdPatient = PatientCreator.CreatePatient(s, patient_name.text, patient_age.text);
        newCreatedPatient = PatientCreator.CreateNewPatient(Name.text, SureName.text, 1, 3, Gender.text, PhoneNumber.text,
            MedicalCompany.text, AddressLocation.text, Complaint.text, measurementArray);//parsing for ints is temp TBF


        treatmentSequenceEditorWindow.gameObject.SetActive(true);
        //treatmentSequenceEditorWindow.Init(createdPatient);
        treatmentSequenceEditorWindow.Init(newCreatedPatient);
        //continue work on setting the patient and filling their Treatment Sequence
    }
    public void SavePatient()
    {
        //PatientCreator.SaveCurrentPatient();
        PatientCreator.SaveNewPatient();
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

