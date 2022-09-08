using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class Test : Treatment
{
    //public object patientDataDelta; //relevant information to display?
    [SerializeField]
    string testName;
    [SerializeField]
    string response;

    //TBF test setter?

    public override object Result()
    {
        return response;
    }
    public override string DisplayStringAsPartOfSequence()
    {
        return $"בדיקה: {testName}";
    }
    public override string TreatmentDisplayNameAsPartOfDatabase()
    {
        return testName;
    }
}
