using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSequenceEditorWindow : MonoBehaviour
{
    Patient newPatient;

    TreatmeantSequence newTreatmeantSequence;


    [SerializeField]
    TreatmentSequenceDisplayer sequenceDisplayer;

    //[SerializeField]
    //NewQuestionWindow newQuestionWindow;

    public System.Action OnSequenceChange;
    public void Init(Patient patient)
    {
        newPatient = patient;
        newTreatmeantSequence = newPatient.GetTreatmeantSequence;
    }
    [ContextMenu("Refresh")]
    public void RefreshDisplay()
    {
        //sequenceTextBox.text = newPatient.GetTreatmeantSequence.AllDisplayStrings();
        sequenceDisplayer.Set(newPatient.GetTreatmeantSequence);
    }

    //BASE logic for all ADD TREATMENT types
     public void AddTreatmentToSequence(SequenceBlock sequenceBlock)
    {
        if(!newPatient || !newPatient.GetTreatmeantSequence)
        {
            Debug.LogError("missing patient or treatmentsequence");
            return;
        }
        newTreatmeantSequence.AddToSequence(sequenceBlock);
    }
   
}
