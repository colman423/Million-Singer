using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class WriteHandler
{

    public static void writeCategories(Cate[] cateList)
    {
        Debug.Log("writing...");
        try
        {
            XDocument doc = XDocument.Load(Application.dataPath + "/Data/category.xml");
            List<XElement> xEleList = doc.Root.Elements("category").ToList();
            for (int i = 0; i < 9; i++)
            {
                XElement xEle = xEleList[i];
                Cate cate = cateList[i];
                xEle.Attribute("id").Value = cate.ID;
                xEle.Value = cate.name.Trim();
                xEle.Attribute("enabled").Value = cate.enabled.ToString();
            }
            doc.Save(Application.dataPath + "/Data/category.xml");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
    }
    public static void writeSongs(string parentID, Song[] songList)
    {
        try
        {
            XDocument doc = XDocument.Load(Application.dataPath + "/Data/"+parentID+".xml");
            List<XElement> xEleList = doc.Root.Elements("song").ToList();
            for (int i = 0; i < 9; i++)
            {
                XElement xEle = xEleList[i];
                Song song = songList[i];
                xEle.Value = song.name.Trim();
                xEle.Attribute("file").Value = song.file;
                xEle.Attribute("enabled").Value = song.enabled.ToString();
            }
            doc.Save(Application.dataPath + "/Data/" + parentID + ".xml");
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
