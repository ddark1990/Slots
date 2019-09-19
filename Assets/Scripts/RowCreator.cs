using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowCreator : MonoBehaviour
{
    //public bool UseIconSize;

    //public float IconHeight;
    //public float IconWidth;
    public Sprite[] Icons; //number of slots

    public GameObject row;
    public float Speed;

    private void Start()
    {
        CreateHolderRow();
    }

    private void Update()
    {
        //row.GetComponent<RectTransform>().localPosition = new Vector2(0, 0.1f * Time.deltaTime);
        //row.transform.localPosition = Vector2.Lerp(row.transform.localPosition, new Vector2(0, 100), Time.time);
        
    }

    private void CreateHolderRow() 
    {
        row = new GameObject("Row", typeof(Image));
        row.GetComponent<Image>().enabled = false;

        row.transform.SetParent(transform);
        row.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        row.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 * Icons.Length); 

        CreateSlotHolders(row.transform); 
    }

    private void CreateSlotHolders(Transform parent)
    {
        for (int i = 0; i < Icons.Length; i++)
        {
            var icon = Icons[i];
            var iconSize = new Vector2(0,0);
            var iconHolder = new GameObject(i.ToString(), typeof(Image));

            iconSize = iconHolder.GetComponent<RectTransform>().sizeDelta;

            var offSet = -iconSize.y * i;

            iconHolder.transform.SetParent(parent);
            iconHolder.GetComponent<RectTransform>().localPosition = new Vector2(0, 0 + offSet);
            iconHolder.GetComponent<RectTransform>().anchorMin = new Vector2(.5f, 1f);
            iconHolder.GetComponent<RectTransform>().anchorMax = new Vector2(.5f, 1f);
            iconHolder.GetComponent<RectTransform>().pivot = new Vector2(.5f, 1f);
            iconHolder.GetComponent<Image>().sprite = icon;
            iconHolder.GetComponent<Image>().preserveAspect = true;
        }
    }
}
