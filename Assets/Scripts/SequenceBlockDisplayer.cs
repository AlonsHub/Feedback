using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceBlockDisplayer : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text displayText;
    [SerializeField]
    UnityEngine.UI.Button xButton;

    SequenceBlock myBlock;
    List<SequenceBlock> listToRemoveMeFrom;
    public void SetMe(SequenceBlock sequenceBlock, List<SequenceBlock> listOfOrigin)
    {
        myBlock = sequenceBlock;
        listToRemoveMeFrom = listOfOrigin;
    }

    public void RemoveMe()
    {
        listToRemoveMeFrom.Remove(myBlock);
        Destroy(gameObject);
    }
}
