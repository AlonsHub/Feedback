using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseTestWindow : MonoBehaviour
{

    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField]
    TestDatabase testDatabase; 


    private void OnEnable()
    {
        if(!testDatabase)
        {
            Debug.LogError("Test database not found!");
            return;
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(testDatabase.GetListOfTreatmentNames());
        dropdown.RefreshShownValue();
    }

    public void OnClickAdd()
    {

    }
}
