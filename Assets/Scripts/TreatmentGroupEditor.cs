﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentGroupEditor : IBlockCollectionEditor
{
    Patient newPatient;

    public TreatmentGroup treatmentGroup {get => (TreatmentGroup)blockCollection; set => blockCollection = value;}

    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;
    [SerializeField]
    BlockCollectionDisplayer sequenceDisplayer; //also works for treatmentGroup

    public System.Action OnSequenceChange;
    public void Init(Patient p)
    {
        newPatient = p;
        treatmentGroup = SO_Creator<TreatmentGroup>.CreateT(p.paitent_name, $"{PatientCreator.patientID}/TreatmentGroups/");
        treatmentGroup.Init();

        treatmentGroup.OnSequenceChange += sequenceDisplayer.Display;

        //sequenceDisplayer.Set(treatmentGroup as IBlockCollection);
        sequenceDisplayer.Set(this);
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
    public override void RemoveTreatment(int index)
    {
        treatmentGroup.RemoveTreatment(index);
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
