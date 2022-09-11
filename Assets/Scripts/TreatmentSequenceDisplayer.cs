using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSequenceDisplayer : MonoBehaviour
{
    //TreatmentSequence treatmeantSequence;
    IBlockCollection treatmeantSequence;
    //List<SequenceBlock> sequenceBlocks;
    //TBF - make these SequenceBlockDisplayer instead of just one text box with several lines or several textBoxes
    [SerializeField]
    TMPro.TMP_Text textBox;
    //public void Set(TreatmentSequence ts)
    //{
    //    treatmeantSequence = ts;
    //    ts.OnSequenceChange += Display;
    //    Display();
    //}
    public void Set(IBlockCollection blockCollection)
    {
        treatmeantSequence = blockCollection;
        //sequenceBlocks = blockCollection.SequenceBlocks();
        blockCollection.OnListChanged(Display);
        //blockCollection.OnListChanged() += Display;

    }

    // public void Set(TreatmentGroup ts)
    //{
    //    treatmeantSequence = ts;
    //    ts.OnSequenceChange += Display;
    //    Display();
    //}

    public void Display()
    {
        //textBox.text = treatmeantSequence.AllDisplayStrings(); //this should go over members and reuse/instantiate a displayer for them?
        textBox.text = treatmeantSequence.AllDisplayStrings(); //this should go over members and reuse/instantiate a displayer for them?
    }
}
