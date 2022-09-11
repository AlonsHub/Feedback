using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class TreatmentGroup : SequenceBlock, IBlockCollection // a group of actions that may be performed in NO particular order
{
    //List<Treatment> treatments; // => new List<Treatment>() with tests and questions

    [SerializeField]
    List<SequenceBlock> treatments; //Could be a list of sequence blocks...
  
    public System.Action OnSequenceChange;

    public void Init()
    {
        treatments = new List<SequenceBlock>();
    }

    public void AddTreatment(SequenceBlock t)
    {
        treatments.Add(t);
        OnSequenceChange?.Invoke();
    }
    public void RemoveTreatment(SequenceBlock t)
    {
        treatments.Remove(t);
        OnSequenceChange?.Invoke();
    }

    public override bool WasPerformed()
    {
        foreach (var item in treatments)
        {
            if (!item.WasPerformed())
                return false;
        }
        return true;
    }
    public string AllDisplayStrings() => DisplayStringAsPartOfSequence();
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

    public List<SequenceBlock> SequenceBlocks()
    {
        return treatments;
    }

    public void OnListChanged(Action func)
    {
        OnSequenceChange += func;
    }
}
