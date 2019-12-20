using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class JsonData : MonoBehaviour
{
    PuzzleData puzzleData;
    SetGrid setGrid;

    string jsonName;

    void Start()
    {
        setGrid = GameObject.Find("Grid").GetComponent<SetGrid>();
        jsonName = 0.ToString();

#if UNITY_EDITOR
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonName + ".json");

#elif UNITY_IOS
        string filePath = Path.Combine (Application.streamingAssetsPath + "/Raw", fileName);
 
#elif UNITY_ANDROID
       string filePath = Path.Combine(Application.streamingAssetsPath + "/"+ jsonName+".json");
 
#endif

        if (File.Exists(filePath))
        {
            print("Dosya var");

#if UNITY_EDITOR || UNITY_IOS
            string json = File.ReadAllText(filePath);


#elif UNITY_ANDROID
            WWW reader = new WWW (filePath);
            while (!reader.isDone) {
            }
            json = reader.text;
#endif

            puzzleData = JsonUtility.FromJson<PuzzleData>(json);
            setGrid.GetJsonData(puzzleData);
            
        }
    }
  
   
}
[System.Serializable]
public class PuzzleData
{
    public string topic;
    public string[] words;
    public int rewardCoin;
    public BoardList board;
     /*public PuzzleData(string topic, string[] words,int rewardCoin, BoardList board)
     {
         this.topic = topic;
         this.words = words;
         this.rewardCoin = rewardCoin;
         this.board = board;
     }*/
}
[System.Serializable]
public class BoardList
{
    public int boardRow;
    public int boardCol;
    public Letters[] letters;

}
[System.Serializable]
public class Letters
{
    public int rowIndex;
    public int colIndex;
    public string letter;
}










