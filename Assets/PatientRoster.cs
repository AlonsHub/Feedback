using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientRoster : MonoBehaviour
{
    [SerializeField]
    GameObject patientButtonPrefab;
    [SerializeField]
    Transform verticalGroup;

    [SerializeField]
    Button editPatientButton;
    List<string> names;

    void Start()
    {
        names = PatientCreator.GetExistingPatientNames();
        string tempName;
        foreach (var item in names)
        {
            GameObject g = Instantiate(patientButtonPrefab, verticalGroup);
            g.GetComponent<DisplayButton>().Set(item, this);
        }
    }
    private void OnEnable()
    {
        PatientCreator.OnPatientClear += ()=>SetEnableEditButton(false);
        PatientCreator.OnLoadPatient += ()=>SetEnableEditButton(true);
    }
    private void OnDisable()
    {
        PatientCreator.OnPatientClear -= ()=>SetEnableEditButton(false);
        PatientCreator.OnLoadPatient -= () => SetEnableEditButton(true);

    }

    public void LoadPatient(string patientFullName)
    {
        if (string.IsNullOrEmpty(patientFullName))
        {
            Debug.LogError("no file name");
            return;
        }
        PatientCreator.LoadPatient(patientFullName);
        //SetEnableEditButton(true); 
    }

    void SetEnableEditButton(bool b)
    {
        editPatientButton.interactable = b;
    }
}
