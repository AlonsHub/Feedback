﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBlockCollectionEditor : MonoBehaviour
{
    public IBlockCollection blockCollection;

    public virtual void AddTreatmentToCollection(SequenceBlock sequenceBlock)
    {

    }

    public virtual void MoveTreatment(int index, int movement)
    {
        blockCollection.MoveIndex(index, movement);
    }

    public virtual void RemoveTreatment(int index)
    {

    }

}
