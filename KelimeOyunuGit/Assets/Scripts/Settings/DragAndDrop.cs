using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DragAndDrop : MonoBehaviour
{
    GameManagerScripts gm;
    public Letter letter = new Letter();

    public bool startSelected,isSelected=false;
    
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScripts>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startSelected = true;
        }
        else{
            startSelected = false;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
    public void OnPointerDown()
    {
        gm.selectedLetters.Add(letter);
        gameObject.GetComponent<Image>().color = Color.grey;

    }

    public void OnPointerEnter()
    {
        if (startSelected == true && isSelected==false)
        {
            gameObject.GetComponent<Image>().color = Color.grey;
            gm.selectedLetters.Add(letter);
            isSelected = true;  
        }
    }
    public void OnPointerExit()
    {
        isSelected = false;
    }
    public void OnPointerUp()
    {
       
        isSelected = false;
        gm.wordCreate();
    }
}
