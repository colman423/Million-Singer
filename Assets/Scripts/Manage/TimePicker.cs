using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using System;

public class TimePicker : MonoBehaviour
{
    public InputField iMin;
    public InputField iSec;
    public InputField iMsec;
    public int getTimeInt()
    {
        int nMin = Int16.Parse(iMin.text);
        int nSec = Int16.Parse(iSec.text);
        int nMsec = Int16.Parse(iMsec.text);
        return nMin * 60 * 100 + nSec * 100 + nMsec;
    }
    public string getTimeString()
    {
        return iMin.text + ":" + iSec.text + "." + iMsec.text;
    }
}
