using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSequenceEditorWindow : IBlockCollectionEditor
{
    Patient newPatient;

    TreatmentSequence newTreatmeantSequence;

    [SerializeField]
    TreatmentGroupEditor treatmentGroupEditor;
    [SerializeField]
    TreatmentSequenceDisplayer sequenceDisplayer;

    
    public void Init(Patient patient)
    {
        newPatient = patient;
        newTreatmeantSequence = newPatient.GetTreatmeantSequence;
        sequenceDisplayer.Set(newTreatmeantSequence as IBlockCollection);
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
        if (!newPatient || !newPatient.GetTreatmeantSequence)
        {
            Debug.LogError("missing patient or treatmentsequence");
            return;
        }
        newTreatmeantSequence.AddToSequence(sequenceBlock);
    }

    public void OpenTreatmentGroupEditor()
    {
        treatmentGroupEditor.gameObject.SetActive(true);
        treatmentGroupEditor.Init(newPatient);
    }
}
