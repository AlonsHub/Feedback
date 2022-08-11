using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Question : Treatment
{
    [SerializeField]
    string answer;
    public override object Result()
    {
        return answer;
    }
}
