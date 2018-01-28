using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

    public Text nameTag;
    public InputField nameInput;
    public GameObject btnRename;
    public GameObject btnRenameConfirm;
    public GameObject btnRenameCancel;
    public GameObject btnGointo;
    public GameObject btnMove;
    public GameObject btnRemove;
    public GameObject normalGroup;
    public GameObject editGroup;

    public string getName()
    {
        return nameTag.text;
    }
    public void setName(string str)
    {
        nameTag.text = str;
    }
    public void editSongName()
    {
        nameInput.text = getName();
        toggleEditMode(true);
        nameInput.Select();
    }
    public void confirmNameChange()
    {
        Debug.Log("confirm name change!");
        setName(nameInput.text);
        toggleEditMode(false);
        WriteHandler.writeSong(); //TODO
    }
    public void cancelNameChange()
    {
        toggleEditMode(false);
    }
    void toggleEditMode(bool isEdit)
    {
        nameInput.gameObject.SetActive(isEdit);
        nameTag.gameObject.SetActive(!isEdit);

        normalGroup.SetActive(!isEdit);
        editGroup.SetActive(isEdit);
    }
    public string getID()
    {
        return gameObject.name;
    }
    public void setID(string ID)
    {
        gameObject.name = ID;
    }
    public bool getActive()
    {
        return gameObject.activeSelf;
        //TODO
    }
    public void setActive(bool isActive)
    {
        List<GameObject> objList = new List<GameObject>();
        objList.Add(gameObject);
        objList.Add(btnRename);
        objList.Add(btnRenameConfirm);
        objList.Add(btnRenameCancel);
        objList.Add(btnGointo);
        objList.Add(btnMove);
        objList.Add(btnRemove);
        foreach (GameObject obj in objList)
        {
            float h, s, v;
            Color.RGBToHSV(obj.GetComponent<Image>().color, out h, out s, out v);
            v = isActive ? v * 2 : v * 0.5f;
            obj.GetComponent<Image>().color = Color.HSVToRGB(h, s, v);
        }
        //TODO
    }
}
