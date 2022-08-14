using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class TreatmeantSequence : ScriptableObject
{
   
    [SerializeField]
    List<SequenceBlock> sequenceBlocks;
    public bool IsComplete()
    {
        foreach (var item in sequenceBlocks)
        {
            if (!item.WasPerformed())
                return false;
        }
        //checks if all parameters were met...
        return true;
    }
}