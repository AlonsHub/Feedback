using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSO : ScriptableObject
{
    [SerializeField]
    Treatment treatment;
    public virtual Treatment Treatment()
    {
        return treatment;
    }
}
