using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ContentEditing : MonoBehaviour
{
    public GameObject prefab;
    Sprite[] backgrounds;
    void Start()
    {
        EditContent();
       
    }

    public void EditContent()
    {
        backgrounds = Resources.LoadAll("backgrounds", typeof(Sprite)).Cast<Sprite>().ToArray();
        foreach (var item in backgrounds)
        {
            GameObject crOb = Instantiate(prefab, transform);
            crOb.transform.GetChild(0).GetComponent<Image>().sprite = item;
            crOb.name = item.name;

        }
    }
}
