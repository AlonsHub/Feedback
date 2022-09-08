using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu()]
public class Question : Treatment
{

    [SerializeField]
    string questionText;
    [SerializeField]
    string answerText;
    /// <summary>
    /// Inits questions.
    /// Should be called when creating a new question
    /// </summary>
    /// <param name="newID">for the Treatment Set() - TBF needs to be pulled from the last used ID, and add 1</param>
    /// <param name="newAnswer">specific patient reply</param>
    public Question SetQuestion(string newID,string newQuestion, string newAnswer)
    {
        questionText = newQuestion;
        answerText = newAnswer;
        base.Set(newID);
        return this;
    }
    public override object Result()
    {
        return answerText;
    }
    public override string DisplayStringAsPartOfSequence()
    {
        return $"שאלה:{questionText} \n תשובה:{answerText}";
    }
    public override string TreatmentDisplayNameAsPartOfDatabase()
    {
        return questionText;
    }
}
