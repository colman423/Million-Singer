using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WriteHandler : MonoBehaviour {
    public GameObject categoryContainer;
    public GameObject songContainer;

    public void writeCategory()
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter("Data/category.txt");
        foreach ( Transform child in categoryContainer.transform )
        {
            string str = child.gameObject.GetComponent<GetSpecificData>().data.GetComponent<Text>().text;
            writer.WriteLine(str);
        }
        writer.Close();
    }
}
