using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentGroupEditor : IBlockCollectionEditor
{
    Patient newPatient;

    TreatmentGroup treatmentGroup;

    [SerializeField]
    TreatmentSequenceDisplayer sequenceDisplayer; //also works for treatmentGroup

    public System.Action OnSequenceChange;
    public void Init(Patient p)
    {
        newPatient = p;
        treatmentGroup = SO_Creator<TreatmentGroup>.CreateT(p.paitent_name);

        sequenceDisplayer.Set(treatmentGroup as IBlockCollection);
    }

    public override void AddTreatmentToCollection(SequenceBlock sequenceBlock)
    {
        if (!newPatient || !newPatient.GetTreatmeantSequence)
        {
            Debug.LogError("missing patient or treatmentsequence");
            return;
        }
        treatmentGroup.AddTreatment(sequenceBlock);
    }

    public void RefreshDisplay()
    {
        sequenceDisplayer.Display();
    }

}
