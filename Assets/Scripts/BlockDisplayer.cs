using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDisplayer : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text displayText;
    [SerializeField]
    UnityEngine.UI.Button xButton;

    public int myIndex;
    //IBlockCollection iBlockCollection;
    IBlockCollectionEditor connectedEditor;
    //SequenceBlock myBlock;
    //List<SequenceBlock> listToRemoveMeFrom;
    public void SetMe(string text, int index, IBlockCollectionEditor blockCollectionEditor)
    {
        displayText.text = text;
        myIndex = index;
        connectedEditor = blockCollectionEditor;
    }
    public void MoveMe(int movement)//works with in scene buttons
    {
        connectedEditor.MoveTreatment(myIndex, movement);
    }
    public void RemoveMe()
    {
        connectedEditor.RemoveTreatment(myIndex);
    }
}
