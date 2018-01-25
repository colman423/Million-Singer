using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ColorManager {
    public static void setBtnColor(Color normalCol)
    {
        Color highlightedCol = getHighlightedColor(normalCol);
        Color pressedCol = getPressedColor(normalCol);

        GameObject[] btns = GameObject.FindGameObjectsWithTag("Button");
        foreach( GameObject btn in btns )
        {
            ColorBlock colBlock = btn.GetComponent<Button>().colors;
            colBlock.normalColor = normalCol;
            colBlock.highlightedColor = highlightedCol;
            colBlock.pressedColor = pressedCol;
            btn.GetComponent<Button>().colors = colBlock;
        }
    }
    public static void setBtnDisabledColor(Color disabledCol)
    {
        GameObject[] btns = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject btn in btns)
        {
            ColorBlock colBlock = btn.GetComponent<Button>().colors;
            colBlock.disabledColor = disabledCol;
            btn.GetComponent<Button>().colors = colBlock;
        }
    }
    static Color getHighlightedColor(Color col)
    {
        return new Color(col.r * 245 / 255, col.g * 245 / 255, col.b * 245 / 255);
    }
    static Color getPressedColor(Color col)
    {
        return new Color(col.r * 200 / 255, col.g * 200 / 255, col.b * 200 / 255);
    }
}
