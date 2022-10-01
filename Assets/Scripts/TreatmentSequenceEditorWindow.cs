using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSequenceEditorWindow : IBlockCollectionEditor
{
    Patient newPatient;

    public TreatmentSequence newTreatmeantSequence { get => (TreatmentSequence)blockCollection; set => blockCollection = value; }


    [SerializeField]
    TreatmentGroupEditor treatmentGroupEditor;
    [SerializeField]
    BlockCollectionDisplayer sequenceDisplayer;

    
    public void Init(Patient patient)
    {
        newPatient = patient;
        newTreatmeantSequence = newPatient.GetTreatmeantSequence;
        //sequenceDisplayer.Set(newTreatmeantSequence as IBlockCollection);
        sequenceDisplayer.Set(this);
    }
    [ContextMenu("Refresh")]
    public void RefreshDisplay()
    {
        //sequenceTextBox.text = newPatient.GetTreatmeantSequence.AllDisplayStrings();
        sequenceDisplayer.Display();
    }

    //BASE logic for all ADD TREATMENT types
    public override void AddTreatmentToCollection(SequenceBlock sequenceBlock)
    {
        if (newPatient ==null|| newPatient.GetTreatmeantSequence ==null)
        {
            Debug.LogError("missing patient or treatmentsequence");
            return;
        }
        newTreatmeantSequence.AddToSequence(sequenceBlock);
    }
    public override void RemoveTreatment(int index)
    {
        newTreatmeantSequence.RemoveFromSequence(index);
    }

    public void OpenTreatmentGroupEditor()
    {
        treatmentGroupEditor.gameObject.SetActive(true);
        treatmentGroupEditor.Init(newPatient);
    }
}
