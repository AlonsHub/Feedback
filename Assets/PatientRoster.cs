using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoster : MonoBehaviour
{
    [SerializeField]
    GameObject patientButtonPrefab;
    [SerializeField]
    Transform verticalGroup;

    List<string> names;

    void Start()
    {
        names = PatientCreator.GetExistingPatientNames();
        string tempName;
        foreach (var item in names)
        {
            GameObject g = Instantiate(patientButtonPrefab, verticalGroup);
            g.GetComponent<DisplayButton>().Set(item);
        }
    }

    
}
