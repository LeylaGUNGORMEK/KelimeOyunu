using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGrid : MonoBehaviour
{
    public PuzzleData puzData;
    public GameObject letterBox;

    public int rows, cols;
    float xStartPosition;
    public Vector2 cellSize;
    public Letters[] letters;

    public void GetJsonData(PuzzleData puzzleData)
    {

        rows = puzzleData.board.boardRow;
        cols = puzzleData.board.boardCol;
        letters = puzzleData.board.letters;
        print(letters[0].letter);

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
        }
        xStartPosition = (cols - rows) * cellSize.x / 2  ;

        SetGridArea(rows, cols, cellSize, letters);

    }
    public void SetGridArea(int rows, int cols, Vector2 cellSize, Letters[] letters)
    {
        GameObject createBox;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 pos = new Vector2(((j * cellSize.x) + cellSize.x / 2) - xStartPosition, (i * cellSize.y) + cellSize.y / 2);
                for (int k = 0; k < letters.Length; k++)
                {
                    if (letters[k].rowIndex == i && letters[k].colIndex == j && letters[k].letter != "0")
                    {
                        createBox = Instantiate(letterBox, transform);
                        createBox.transform.localPosition = pos;
                        createBox.GetComponent<RectTransform>().sizeDelta = cellSize;
                        createBox.name = letters[k].letter;
                        createBox.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("alfabe/"+createBox.name);
                        

                    }
                }

            }
        }
    }
}