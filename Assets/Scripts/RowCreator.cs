using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowCreator : MonoBehaviour
{
    public bool UseIconHeight;
    public bool UseIconWidth;

    public float IconHeight;
    public float IconWidth;
    public Sprite[] Icons; //number of slots

    //public float RowHeight;
    //public float RowWidth;


    private void Init()
    {

    }

    private void Start()
    {
        CreateHolderRow(IconHeight, IconWidth);
    }

    private void CreateHolderRow(float rowHeight, float rowWidth)
    {
        var row = new GameObject("Row", typeof(Image));
        row.GetComponent<Image>().enabled = false;
        row.transform.SetParent(transform);
        //row.transform.localPosition = new Vector2(0,0);
        //row.transform.localScale = new Vector2(rowHeight, rowWidth);
        row.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        row.GetComponent<RectTransform>().sizeDelta = new Vector2(rowWidth, rowHeight * Icons.Length);
        CreateSlotHolders(row.transform);
    }

    private void CreateSlotHolders(Transform parent)
    {
        for (int i = 0; i < Icons.Length; i++)
        {
            Sprite icon = Icons[i];
            var iconHolder = new GameObject((i).ToString(), typeof(Image));

            int iconNumber = i;
            Vector2 iconSize;

            iconSize = iconHolder.GetComponent<RectTransform>().sizeDelta;
            var offSet = -iconSize.y * iconNumber;

            iconHolder.transform.SetParent(parent);
            iconHolder.GetComponent<RectTransform>().localPosition = new Vector2(0, 0 + offSet);
            iconHolder.GetComponent<RectTransform>().anchorMin = new Vector2(.5f, 1f);
            iconHolder.GetComponent<RectTransform>().anchorMax = new Vector2(.5f, 1f);
            iconHolder.GetComponent<RectTransform>().pivot = new Vector2(.5f, 1f);
            iconHolder.GetComponent<Image>().sprite = icon;
        }
    }
}
