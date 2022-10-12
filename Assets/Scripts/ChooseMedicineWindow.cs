using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseMedicineWindow : NewBlockWindow
{
    [SerializeField]
    UnityEngine.UI.Toggle doClose;
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField]
    TMP_InputField TEMP_patientData; //Look below.
    //PatientMeasurementInput TBF!
    //^^^ much like a displayer, this component will provide string input fields, corresponding to the parameters of patientMeasurementData.
    //^^^ this UI prefab will then easily parse all input fields (each field to int/float/enum etc...) - to create a fresh patientMeasurementData.
    //^^^ use this to initially set all patientMeasurementData on a new patient AND for medicine effect (as a "delta_patientMeasurementData" -> where only "fields to be changed" have value)

    [SerializeField]
    Databases databases;
    [SerializeField]
    MedicineDB medicineDatabase;

    [SerializeField]
    BlockCollectionEditor treatmentSequenceEditorWindow;

    public override void OnEnable()
    {
        if (databases == null)
        {
            Debug.LogError("Test database not found!");
            return;
        }

        RefreshDropdownMedicine();
        base.OnEnable();
    }
    public override void OnDisable()
    {
        //set all fields to nothing
        TEMP_patientData.text = "";
        base.OnDisable();
    }
    private void RefreshDropdownMedicine()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(databases.medicineDB.GetListOfTreatmentNames());
        dropdown.RefreshShownValue();
    }

    public void OnClickAdd() //Set in inspector
    {
        if (string.IsNullOrEmpty(TEMP_patientData.text))
            return;

        Medicine temp= databases.medicineDB.GetTreatmentByIndex(dropdown.value);
        Medicine med = MedicineCreator.CreateMedicine(temp.ID(), temp.medicineName, TEMP_patientData.text);

        //med.Init(TEMP_patientData.text); //This needs to just send patientMeasurementData tbf
        //Set med's result (as PatientMeasurementData - taken from the PatientMeasurementInput TBF!

        treatmentSequenceEditorWindow.AddTreatmentToCollection(med);
        if (doClose.isOn)
        {
            gameObject.SetActive(false);
        }
    }

}
