using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abstract class that describes ANY patient-interaction that has medical/treatment implications.
/// Including: Questions, Tests, and Medicine. 
/// Give injection, perform CPR, underss patient, ask patient their age)
/// </summary>
[System.Serializable]
public abstract class Treatment : SequenceBlock
{
    [SerializeField]
    protected string id;
    //identification of question, test or device
    public virtual string ID()
    {
        return id;
    }
    //may be either playerDataDelta - or Answer to question
    public abstract object Result();

    public bool WasPerformed()
    {
        return false;
    }
}
