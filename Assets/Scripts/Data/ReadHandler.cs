using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ReadHandler : MonoBehaviour {

    public GameObject categoryContainer;
    public GameObject songContainer;

    private void Start()
    {
        readCategory();
    }
    public void readCategory()
    {
        categoryContainer.GetComponent<Text>().text = Application.dataPath;
        try
        {
            List<XElement> cateList = XDocument.Load(Application.dataPath + "/Data/category.xml").Element("root").Elements("category").ToList();
            for( int i=0; i<9; i++ )
            {
                XElement xEle = cateList[i];
                GameObject gObj = categoryContainer.transform.GetChild(i).gameObject;
                Debug.Log(gObj.name);
                Debug.Log(xEle.ToString());

                string ID = xEle.Attribute("id").Value.Trim();
                string name = xEle.Value.Trim();
                bool enabled = bool.Parse(xEle.Attribute("enabled").Value.Trim());

                gObj.name = ID;
                gObj.GetComponent<CategoryManager>().setCategoryName(name);
                gObj.SetActive(enabled);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
    }
}
