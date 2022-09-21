using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlockWindow : MonoBehaviour
{
    public static NewBlockWindow CurrentlyOpenWindow;

    public virtual void OnEnable()
    {
        if(CurrentlyOpenWindow && CurrentlyOpenWindow!=this)
        {
            CurrentlyOpenWindow.gameObject.SetActive(false); //maybe should just have a custom Disable method for NewBlockWindow? 
        }
        CurrentlyOpenWindow = this;
    }
    //CustomDisable
    public virtual void OnDisable()
    {
        
    }
}
