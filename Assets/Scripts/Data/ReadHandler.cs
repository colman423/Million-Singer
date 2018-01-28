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
        readCategories();
    }
    public void readCategories()
    {
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

                gObj.GetComponent<CategoryManager>().setID(ID);
                gObj.GetComponent<CategoryManager>().setName(name);
                gObj.SetActive(enabled);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            WriteHandler.writeDefault();
        }
    }
    public void readSongs(string cateID)
    {
        gameObject.GetComponent<ManageHandler>().changeToSongTab();
        try
        {
            List<XElement> songList = XDocument.Load(Application.dataPath + "/Data/"+cateID+".xml").Element("root").Elements("song").ToList();
            for (int i = 0; i < 9; i++)
            {
                XElement xEle = songList[i];
                GameObject gObj = songContainer.transform.GetChild(i).gameObject;
                Debug.Log(gObj.name);
                Debug.Log(xEle.ToString());
                
                string name = xEle.Value.Trim();
                bool enabled = bool.Parse(xEle.Attribute("enabled").Value.Trim());
                
                gObj.GetComponent<SongManager>().setName(name);
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
