﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public Text loadingText;
    
   
    public void LoadLevel(string sceneName )
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }
    public IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            loadingText.text = (int)progress * 100f+"%";
            yield return null;
        }

        
    }
    public void CloseGame()
    {
        Application.Quit();
    }
   
}
