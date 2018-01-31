using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class ReadHandler {

    public static Cate[] readCategories()
    {
        Cate[] cateList = new Cate[9];
        try
        {
            List<XElement> xEleList = XDocument.Load(Application.dataPath + "/Data/category.xml").Root.Elements("category").ToList();
            for( int i=0; i<9; i++ )
            {
                XElement xEle = xEleList[i];

                string ID = xEle.Attribute("id").Value.Trim();
                string name = xEle.Value.Trim();
                bool enabled = bool.Parse(xEle.Attribute("enabled").Value.Trim());

                cateList[i] = new Cate(ID, name, enabled);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
        return cateList;
    }
    public static Song[] readSongs(string cateID)
    {
        Song[] songList = new Song[9];
        //gameObject.GetComponent<ManageHandler>().changeToSongTab();
        //songContainer.name = cateID;
        try
        {
            List<XElement> xEleList = XDocument.Load(Application.dataPath + "/Data/"+cateID+".xml").Root.Elements("song").ToList();
            for (int i = 0; i < 9; i++)
            {
                XElement xEle = xEleList[i];
                
                string name = xEle.Value.Trim();
                string file = xEle.Attribute("file").Value.Trim();
                bool enabled = bool.Parse(xEle.Attribute("enabled").Value.Trim());

                songList[i] = new Song(name, file, enabled);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
        return songList;

    }
}
