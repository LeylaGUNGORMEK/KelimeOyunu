using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundUpdater : MonoBehaviour
{
    string bgName;
    void Start()
    {

        bgName = PlayerPrefs.GetString("backgroundName");
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("backgrounds/" + bgName);
    }

    public void UpdateBackground(string name)
    {
        bgName = name;
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("backgrounds/" + bgName);
        PlayerPrefs.SetString("backgroundName", bgName);
    }
}
