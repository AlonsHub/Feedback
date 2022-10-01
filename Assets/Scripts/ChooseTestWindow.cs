using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseTestWindow : NewBlockWindow
{

    [SerializeField]
    UnityEngine.UI.Toggle doClose;
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField]
    TestDatabase testDatabase;

    [SerializeField]
    IBlockCollectionEditor treatmentSequenceEditorWindow;
    public override void OnEnable()
    {
        base.OnEnable();
        if (testDatabase == null)
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
        treatmentSequenceEditorWindow.AddTreatmentToCollection(testDatabase.GetTreatmentByIndex(dropdown.value));
        if(doClose.isOn)
        {
            gameObject.SetActive(false);
        }
    }
}
