using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBackground : MonoBehaviour
{
    GameObject background;
    
    
    public void SelectBackground()
    {
        background = GameObject.Find("backgroundIm");
        background.GetComponent<BackgroundUpdater>().UpdateBackground(gameObject.name);
        
    }
   
}
