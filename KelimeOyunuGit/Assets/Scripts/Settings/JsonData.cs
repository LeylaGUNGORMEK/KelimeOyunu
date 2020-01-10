using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class JsonData : MonoBehaviour
{
    PuzzleData puzzleData;
    SetGrid setGrid;
    GameManagerScripts gm;

    int sceneName;

    void Start()
    {
        setGrid = GameObject.Find("LetterArea").GetComponent<SetGrid>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScripts>();

        sceneName = PlayerPrefs.GetInt("scName");
        SceneController(sceneName);
        

    }

    public void SceneController(int jsonName)
    {
        sceneName = jsonName;
        PlayerPrefs.SetInt("scName", sceneName);
#if UNITY_EDITOR
        string filePath = Path.Combine(Application.streamingAssetsPath, sceneName.ToString()+ ".json");

#elif UNITY_IOS
        string filePath = Path.Combine (Application.streamingAssetsPath + "/Raw", fileName);
 
#elif UNITY_ANDROID
       string filePath = Path.Combine(Application.streamingAssetsPath + "/"+ jsonName+".json");
 
#endif

        if (File.Exists(filePath))
        {

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
            gm.GetJsonData(puzzleData);

        }
    }
}



