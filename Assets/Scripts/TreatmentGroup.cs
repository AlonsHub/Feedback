using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class TreatmentGroup : SequenceBlock // a group of actions that may be performed in NO particular order
{
    //List<Treatment> treatments; // => new List<Treatment>() with tests and questions

    [SerializeField]
    List<Treatment> treatments;
    //[SerializeField]
    //List<TestSO> testsSO;
    //[SerializeField]
    //List<QuestionSO> questionsSO;

    //public List<Treatment> GetTreatments()
    //{
    //    treatments = new List<Treatment>();
    //    foreach (var item in treatmentSOs)
    //    {
    //        treatments.Add(item.Treatment());
    //    }
         
    //    return treatments;
    //}

    public override bool WasPerformed()
    {
        return true;
    }

    public override string DisplayStringAsPartOfSequence()
    {
        if (treatments.Count == 0)
            return "";

        string toReturn = "";// treatments[0].DisplayString();
        for (int i = 0; i < treatments.Count; i++)
        {
            toReturn += $"{treatments[i]}\n";
        }
        return base.DisplayStringAsPartOfSequence();
    }

}
