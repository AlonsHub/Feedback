using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewQuestionWindow : MonoBehaviour
{
    [SerializeField]
    TMP_InputField questionText;
    [SerializeField]
    TMP_InputField replyText;

    [SerializeField]
    IBlockCollectionEditor treatmentSequenceEditorWindow;
    //private void OnEnable()
    //{
    //    questionText.text = " ";
    //    replyText.text = " ";
    //}
    public void ClickOnCreateNew()
    {
        if (string.IsNullOrEmpty(questionText.text) || string.IsNullOrEmpty(replyText.text))
        {
            Debug.LogError("both reply and question text needs to be added");
            return;
        }
        treatmentSequenceEditorWindow.AddTreatmentToCollection(QuestionCreator.CreateQuestion($"q_{System.DateTime.Now.ToString("h-m")}", questionText.text, replyText.text));

        //Release addbuttons-lock? tbf
        questionText.text = "";
        replyText.text = "";

        gameObject.SetActive(false);

        //Invoke("Kill", .2f);
    }
    //void Kill() => gameObject.SetActive(false);
}
