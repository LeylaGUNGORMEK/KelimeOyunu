using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI ;


public class GameManagerScripts : MonoBehaviour
{
    PuzzleData puzzleData;

    public List<Letter> allLeters = new List<Letter>();
    public List<Letter> selectedLetters = new List<Letter>();
    private List<int> xList = new List<int>();

    public string[] correctWords;
    string createdWord;

    public int sceneCount;

    public GameObject finishPanel,loadingText;
    public Text episodeText;
     void Start()
    {
        sceneCount = PlayerPrefs.GetInt("scCount");
        
    }
     void Update()
    {
        episodeText.text = sceneCount + "";
    }
    public void GetJsonData(PuzzleData _puzzleData)
    {
        puzzleData = _puzzleData;
        correctWords = puzzleData.words;
    }
    public void wordCreate()
    {
        createdWord = null;
        foreach (var item in selectedLetters)
        {
            createdWord += item.letterBox.name;
        }
        wordControll(createdWord);
    }
    public void wordControll(string _word)
    {
        var answer = correctWords.FirstOrDefault(x => x.Equals(_word));
        if (answer != null)
        {
            EditLetters();
        }
        else
        {
            print("Kelimeler Eşleşmedi");
        }
        selectedLetters.Clear();
    }
    public void EditLetters()
    {
        xList.Clear();
        foreach (var letter in selectedLetters)
        {
            if (!xList.Contains(letter.x))
                xList.Add(letter.x);
        }
        foreach (int x in xList)
        {
            while (FindBiggest(x, selectedLetters) != -1)
            {
                int selectedMaxY = FindBiggest(x, selectedLetters);
                int allMaxY = FindBiggest(x, allLeters);

                if (selectedMaxY != allMaxY || selectedMaxY != 0)
                {
                    for (int i = selectedMaxY; i < allMaxY; i++)
                    {
                        Letter sLetter = allLeters.FirstOrDefault<Letter>(lt => lt.x == x && lt.y == i);
                        Letter bLetter = allLeters.FirstOrDefault<Letter>(lt => lt.x == x && lt.y == i + 1);
                        int sY = sLetter.y;
                        int bY = bLetter.y;
                        Vector2 sPos = sLetter.letterBox.transform.position;
                        Vector2 bPos = bLetter.letterBox.transform.position;
                        if (bLetter != null)
                        {
                            Swap(ref sLetter, ref bLetter);
                            sLetter.y = sY;
                            bLetter.y = bY;
                            sLetter.letterBox.GetComponent<DragAndDrop>().letter.y = sLetter.y;
                            sLetter.letterBox.transform.position = sPos;
                            bLetter.letterBox.transform.position = bPos;
                        }
                    }
                }
                else
                {
                    print("burası boş kaldı" + x);
                    List<int> deletedXList = new List<int>();
                    if (!deletedXList.Contains(x))
                        deletedXList.Add(x);
                    foreach (var letter in allLeters)
                    {
                        float changeAmount = (letter.letterBox.GetComponent<RectTransform>().rect.width / 2)* deletedXList.Count;
                        if (letter.x < x)
                        {
                            letter.letterBox.transform.localPosition = new Vector2
                                (letter.letterBox.transform.localPosition.x + changeAmount, letter.letterBox.transform.localPosition.y);
                        }
                        else
                        {
                            letter.letterBox.transform.localPosition = new Vector2
                                 (letter.letterBox.transform.localPosition.x - changeAmount, letter.letterBox.transform.localPosition.y);   
                        }
                    }
                }
                DeleteLetter(x, selectedMaxY, selectedLetters);
                DeleteLetter(x, allMaxY, allLeters);
            }
        }
        xList.Clear();
        if (allLeters.Count == 0)
        {
            finishPanel.SetActive(true);
        }
           
    }
    public int FindBiggest(int x, List<Letter> list)
    {
        int temp = -1;
        foreach (var item in list)
        {
            if (item.x == x)
            {
                if (temp < item.y)
                {
                    temp = item.y;
                }
            }
        }
        return temp;
    }
    public void DeleteLetter(int x, int y, List<Letter> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].x == x && list[i].y == y)
            {
                print($"silinecek  x:{list[i].x} y:{list[i].y} name:{list[i].letterBox.name}");
                Destroy(list[i].letterBox);
                list.RemoveAt(i);
            }
        }
    }
    public void Swap<T>(ref T sValue, ref T bValue)
    {
        T temp;
        temp = bValue;
        bValue = sValue;
        sValue = temp;
    }
    
    public void NewSceneButton()
    {
        sceneCount++;
        PlayerPrefs.SetInt("scCount", sceneCount);
        StartCoroutine(CreateScreen());

        
    }
    IEnumerator CreateScreen()
    {

        yield return new WaitForSeconds(3f) ;
        loadingText.SetActive(false);
       
        Camera.main.GetComponent<JsonData>().SceneController(sceneCount);
        
    }
    public void TakeReward()
    {
        print(puzzleData.rewardCoin);
    }
}