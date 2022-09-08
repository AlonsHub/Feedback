using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentSequenceDisplayer : MonoBehaviour
{
    TreatmeantSequence treatmeantSequence;

    //TBF - make these SequenceBlockDisplayer instead of just one text box with several lines or several textBoxes
    [SerializeField]
    TMPro.TMP_Text textBox;
    public void Set(TreatmeantSequence ts)
    {
        treatmeantSequence = ts;
        ts.OnSequenceChange += Display;
        Display();
    }
    public void Display()
    {
        textBox.text = treatmeantSequence.AllDisplayStrings();
    }
}
