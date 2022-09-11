using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class TreatmentSequence : ScriptableObject, IBlockCollection
{
    public List<SequenceBlock> sequenceBlocks;

    public System.Action OnSequenceChange;



    public void Init()
    {
        sequenceBlocks = new List<SequenceBlock>();
    }

    //sequence changing methods
    /// <summary>
    /// adds block to end of list
    /// </summary>
    /// <param name="sequenceBlock"></param>
    public void AddToSequence(SequenceBlock sequenceBlock)
    {
        sequenceBlocks.Add(sequenceBlock);
        OnSequenceChange?.Invoke();
    }
    /// <summary>
    /// add block at index and push rest down
    /// </summary>
    /// <param name="index"></param>
    public void AddToSequence(SequenceBlock sequenceBlock,int index)
    {
        sequenceBlocks.Insert(index, sequenceBlock);
        OnSequenceChange?.Invoke();
    }

    /// <summary>
    /// removes block at index
    /// </summary>
    /// <param name="index"></param>
    public void RemoveFromSequence(int index)
    {
        sequenceBlocks.RemoveAt(index);
        OnSequenceChange?.Invoke();
    }
    /// <summary>
    /// removes block by reference
    /// </summary>
    /// <param name="sequenceBlock"></param>
    public void RemoveFromSequence(SequenceBlock sequenceBlock)
    {
        sequenceBlocks.Remove(sequenceBlock);
        OnSequenceChange?.Invoke();
    }



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

    public string AllDisplayStrings()
    {
        if (sequenceBlocks.Count == 0)
            return "";

        string toReturn="";//= sequenceBlocks[0].DisplayString();
        for (int i = 0; i < sequenceBlocks.Count; i++)
        {
            toReturn += $"\n{sequenceBlocks[i].DisplayStringAsPartOfSequence()}\n";
        }

        return toReturn;
    }

    public List<SequenceBlock> SequenceBlocks() => sequenceBlocks;
    

    public void OnListChanged(System.Action func)
    {
        OnSequenceChange += func;
    }

    
}