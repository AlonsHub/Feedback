using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentDB<T> : ScriptableObject
{
    // Databases all treatments or is good for creating seperate DB's per type
    [SerializeField]
    List<T> treatments;
    [SerializeField]
    protected List<T> tempTreatments;

    public T GetTreatmentByIndex(int index) => treatments[index]; //this is virtual in case 
    public virtual List<T> GetFullList() => treatments;
    
    public List<T> GetTreatmentsWithLinq(System.Func<T,bool> pred)
    {
        return treatments.Where(pred).ToList();
    }

    
}
