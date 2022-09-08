using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseTestWindow : MonoBehaviour
{

    [SerializeField]
    UnityEngine.UI.Toggle doClose;
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField]
    TestDatabase testDatabase;

    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;
    private void OnEnable()
    {
        if (!testDatabase)
        {
            Debug.LogError("Test database not found!");
            return;
        }

        RefreshDropdownTests();
    }

    private void RefreshDropdownTests()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(testDatabase.GetListOfTreatmentNames());
        dropdown.RefreshShownValue();
    }

    public void OnClickAdd()
    {
        treatmentSequenceEditorWindow.AddTreatmentToSequence(testDatabase.GetTreatmentByIndex(dropdown.value));
        if(doClose.isOn)
        {
            gameObject.SetActive(false);
        }
    }
}
