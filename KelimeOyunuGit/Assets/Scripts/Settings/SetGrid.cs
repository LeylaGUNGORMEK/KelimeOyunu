using Assets.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGrid : MonoBehaviour
{
    public PuzzleData puzData;
    public GameObject letterBox;

    GameManagerScripts gm;
    
    

    public int rows, cols;
    float xStartPosition,yStartPosition=750f;
    public Vector2 cellSize;
    public Letters[] letters;


     void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScripts>();
        
    }
    public void GetJsonData(PuzzleData puzzleData)
    {
        rows = puzzleData.board.boardRow;
        cols = puzzleData.board.boardCol;
        letters = puzzleData.board.letters;

        RectTransform parent = gameObject.GetComponent<RectTransform>();
        cellSize = new Vector2((parent.rect.width) / cols, (parent.rect.height) / rows);
        if (cellSize.x != cellSize.y)
        {
            if (cellSize.x > cellSize.y)
            {
                cellSize.x = cellSize.y;
            }
            else
            {
                cellSize.y = cellSize.x;
                
            }
            if (cellSize.x > 250)
            {
                cellSize = new Vector2(250, 250);
            }
           
        }
        xStartPosition = (parent.rect.width - (cellSize.x*cols))/2  ;

        SetGridArea(rows, cols, cellSize, letters);

    }
    public void SetGridArea(int rows, int cols, Vector2 cellSize, Letters[] letters)
    {
        GameObject createBox;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 pos = new Vector2(((j * cellSize.x) + cellSize.x / 2) + xStartPosition, (i * cellSize.y) +( cellSize.y / 2 ) + yStartPosition);
                for (int k = 0; k < letters.Length; k++)
                {
                    if (letters[k].rowIndex == i && letters[k].colIndex == j && letters[k].letter != "0")
                    {
                        createBox = Instantiate(letterBox, transform);
                        createBox.GetComponent<RectTransform>().sizeDelta = cellSize;
                        createBox.transform.localPosition = pos;
                        StartCoroutine(StartAnim(pos, createBox));


                        createBox.name = letters[k].letter;
                        createBox.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("alfabe/"+createBox.name);
                        createBox.GetComponent<DragAndDrop>().letter = (CreateLetter(j,i, createBox));
                        gm.allLeters.Add(CreateLetter(j, i, createBox));
                        
                    }
                }

            }
        }
    }
    public Letter CreateLetter(int x, int y, GameObject letterBox)
    {
        Letter letter = new Letter();
        letter.x = x;
        letter.y = y;
        letter.letterBox = letterBox;
        return letter;
    }
    
    IEnumerator StartAnim(Vector2 pos, GameObject crBox)
    {
        float i = .0f;
        Vector2 newPos = new Vector2(pos.x, pos.y - yStartPosition + cellSize.y / 2);
        while (i < 2f)
        {
            i += Time.deltaTime * 1;
            crBox.transform.position = Vector3.Lerp(pos, newPos, i);
            yield return null;
        }
        
        
        
    }
    private void Update()
    {
        
    }


}

class Animal
{
    public int Yas { get; set; }
    public int test()
    {
        return 1;
    }
}

class Cat : Animal
{
    public void cacluladeAge()
    {
        Debug.Log(Yas);
        Debug.Log(test());
    }
}

class Dog : Animal
{
    public void cacluladeAge()
    {
        Debug.Log(Yas);
        Debug.Log(test());
    }

    public int test()
    {
        return 2;
    }
}

