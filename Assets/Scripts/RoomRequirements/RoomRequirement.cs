using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TrueFalse - for checkboxes
/// SpecificEnum - for things like Pupils (dialted, only left, only right)
/// NumberAmount - for amounts of meds given
/// </summary>
public enum RequirementType {TrueFalse, SpecificEnum, NumberAmount, EventListener};

[System.Serializable]
public class RoomRequirement
{
    public string title;
    public object value; //optional
    public RequirementType requirementType;
   
    public T TryValueByType<T>()
    {
        return (T)value;
    }
}
