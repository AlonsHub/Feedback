using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DisplayButton : MonoBehaviour
{

    [SerializeField]
    TMP_Text text;
    //[SerializeField]
    //Button button;

    string fileNameToLoad;

    public void Set(string patientName)
    {
        text.text = patientName;
        fileNameToLoad = patientName;
    }

    public void LoadThisPatient() // called in inspector by button
    {
        if(string.IsNullOrEmpty(fileNameToLoad))
        {
            Debug.LogError("no file name");
            return;
        }
        PatientCreator.LoadPatient(fileNameToLoad);
    }
}
