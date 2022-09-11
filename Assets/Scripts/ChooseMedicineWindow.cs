using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseMedicineWindow : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Toggle doClose;
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField]
    TMP_Text TEMP_patientData; //Look below.
    //PatientMeasurementInput TBF!
    //^^^ much like a displayer, this component will provide string input fields, corresponding to the parameters of patientMeasurementData.
    //^^^ this UI prefab will then easily parse all input fields (each field to int/float/enum etc...) - to create a fresh patientMeasurementData.
    //^^^ use this to initially set all patientMeasurementData on a new patient AND for medicine effect (as a "delta_patientMeasurementData" -> where only "fields to be changed" have value)


    [SerializeField]
    MedicineDB medicineDatabase;

    [SerializeField]
    IBlockCollectionEditor treatmentSequenceEditorWindow;

    private void OnEnable()
    {
        if (!medicineDatabase)
        {
            Debug.LogError("Test database not found!");
            return;
        }

        RefreshDropdownMedicine();
    }

    private void RefreshDropdownMedicine()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(medicineDatabase.GetListOfTreatmentNames());
        dropdown.RefreshShownValue();
    }

    public void OnClickAdd()
    {
        if (string.IsNullOrEmpty(TEMP_patientData.text))
            return;

        Medicine med = medicineDatabase.GetTreatmentByIndex(dropdown.value);
        med.SetPatientData(TEMP_patientData.text); //This needs to just send patientMeasurementData tbf
        //Set med's result (as PatientMeasurementData - taken from the PatientMeasurementInput TBF!

        treatmentSequenceEditorWindow.AddTreatmentToCollection(med);
        if (doClose.isOn)
        {
            gameObject.SetActive(false);
        }
    }

}
