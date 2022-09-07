using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class Medicine : Treatment
{
    //Currently dosage is part of the unique ID, so basically 10mg of drug X
    [SerializeField]
    object patientData;


    public override object Result()
    {
        return patientData;
    }
}
