using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentDB<T> where T : Treatment
{
    // Databases all treatments or is good for creating seperate DB's per type
    [SerializeField]
    List<T> treatments;
    [SerializeField]
    protected List<T> tempTreatments;

    public T GetTreatmentByIndex(int index) => treatments[index]; //this is virtual in case 
    public virtual List<T> GetFullList() => treatments;
    public virtual List<string> GetListOfTreatmentNames()
    {
        if(treatments==null || treatments.Count == 0)
        {
            Debug.LogError("no treatments found!");
            return null;
        }

        List<string> toReturn = new List<string>();

        foreach (Treatment item in treatments)
        {
            toReturn.Add(item.TreatmentDisplayNameAsPartOfDatabase());
        }
        return toReturn;
    }
    public List<T> GetTreatmentsWithLinq(System.Func<T,bool> pred)
    {
        return treatments.Where(pred).ToList();
    }

    
}
