using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        initialConfig();
	}
	
    void initialConfig()
    {
        Color btnColor = new Color(0f, 142/(float)255, 224/(float)255);
        string music = "雨季.wma";
        ColorManager.setBtnColor(btnColor);
        ColorManager.setBtnDisabledColor(Color.red);
    }
}
