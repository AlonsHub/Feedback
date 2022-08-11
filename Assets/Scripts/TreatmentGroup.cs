using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TreatmentGroup : SequenceBlock // a group of actions that may be performed in NO particular order
{
    List<Treatment> treatments; // => new List<Treatment>() with tests and questions

    [SerializeField]
    List<Test> tests;
    [SerializeField]
    List<Question> questions;
    public bool WasPerformed()
    {
        return true;
    }
}
