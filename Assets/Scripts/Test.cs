using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Test : Treatment
{
    public object patientDataDelta; //relevant information to display?
    public override object Result()
    {
        return patientDataDelta;
    }
}
