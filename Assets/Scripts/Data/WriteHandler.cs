using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WriteHandler
{
    public GameObject categoryContainer;
    public GameObject songContainer;

    public static void writeCategory(string ID, bool enabled, string name)
    {
        try
        {
            XDocument doc = XDocument.Load(Application.dataPath + "/Data/category.xml");
            List<XElement> cateList = doc.Element("root").Elements("category").ToList();
            for (int i = 0; i < 9; i++)
            {
                XElement xEle = cateList[i];
                if (xEle.Attribute("id").Value.Trim() == ID.Trim())
                {
                    xEle.Value = name.Trim();
                    xEle.Attribute("enabled").Value = enabled.ToString();
                }
            }
            doc.Save(Application.dataPath + "/Data/category.xml");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
    }


    public static void writeDefault()
    {

    }
}
