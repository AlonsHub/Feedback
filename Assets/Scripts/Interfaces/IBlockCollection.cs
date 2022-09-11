using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockCollection
{
    List<SequenceBlock> SequenceBlocks();
    void OnListChanged(System.Action func);

    string AllDisplayStrings();

}
