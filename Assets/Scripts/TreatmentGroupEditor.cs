using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentGroupEditor : IBlockCollectionEditor
{
    Patient newPatient;

    TreatmentGroup treatmentGroup;

    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;
    [SerializeField]
    TreatmentSequenceDisplayer sequenceDisplayer; //also works for treatmentGroup

    public System.Action OnSequenceChange;
    public void Init(Patient p)
    {
        newPatient = p;
        treatmentGroup = SO_Creator<TreatmentGroup>.CreateT(p.paitent_name);
        treatmentGroup.Init();

        treatmentGroup.OnSequenceChange += sequenceDisplayer.Display;

        sequenceDisplayer.Set(treatmentGroup as IBlockCollection);
    }

    public override void AddTreatmentToCollection(SequenceBlock sequenceBlock)
    {
        if (!newPatient )
        {
            Debug.LogError("missing patient");
            return;
        }
        treatmentGroup.AddTreatment(sequenceBlock as Treatment);
    }

    public void RefreshDisplay()
    {
        sequenceDisplayer.Display();
    }

    public void AddTreatmentGroupToSequence()
    {
        treatmentSequenceEditorWindow.AddTreatmentToCollection(treatmentGroup);

        gameObject.SetActive(false);
    }
}
