using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GridText : MonoBehaviour
{
    public Grid grid;
    public TMP_Text gridLabel;
    public int sizeX;
    public int sizeY;

    void Awake()
    {
        GameObject canvas = grid.transform.Find("Canvas").gameObject;

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                TMP_Text newlabel = Instantiate(gridLabel);
                newlabel.rectTransform.SetParent(canvas.transform, false);
                newlabel.rectTransform.anchoredPosition = new Vector2(x + 0.5f, y + 0.5f);
                newlabel.text = x + ", " + y;
            }
        }
    }
}
