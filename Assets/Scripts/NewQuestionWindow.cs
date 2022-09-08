using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewQuestionWindow : MonoBehaviour
{
    [SerializeField]
    TMP_Text questionText;
    [SerializeField]
    TMP_Text replyText;

    [SerializeField]
    TreatmentSequenceEditorWindow treatmentSequenceEditorWindow;
    public void ClickOnCreateNew()
    {
        if (string.IsNullOrEmpty(questionText.text) || string.IsNullOrEmpty(replyText.text))
        {
            Debug.LogError("both reply and question text needs to be added");
            return;
        }
        treatmentSequenceEditorWindow.AddTreatmentToSequence(QuestionCreator.CreateQuestion($"q_{System.DateTime.Now.ToString("h-m")}", questionText.text, replyText.text));
        gameObject.SetActive(false);

        //Release addbuttons-lock? tbf
    }

}
