using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSheet : MonoBehaviour
{
    //held on patients - describes the actions required by the exam
    public string patientID;
    public List<string> actions;

    private void Start()
    {
        FeedbackMaster.Instance.AddPatient(this);
    }
}
