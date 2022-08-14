using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class Test : Treatment
{
    public object patientDataDelta; //relevant information to display?
    [SerializeField]
    string response;
    public override object Result()
    {
        return response;
    }
}
