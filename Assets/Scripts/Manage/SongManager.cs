using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

    public Text nameTag;
    public InputField nameInput;
    public GameObject normalGroup;
    public GameObject editGroup;
    public Toggle toggle;
    public ManageHandler mngHdlr;
    
    string fileName;
    bool isFileNameEditing = false;
    bool toggleIsSet = false;

    public string getName()
    {
        return nameTag.text;
    }
    public void setName(string str)
    {
        nameTag.text = str;
    }
    public void editName()
    {
        isFileNameEditing = false;
        nameInput.text = getName();
        toggleEditMode(true);
        nameInput.Select();
    }
    public string getFileName()
    {
        return fileName;
    }
    public void setFileName(string str)
    {
        fileName = str;
    }
    public void editFileName()
    {
        isFileNameEditing = true;
        nameInput.text = getFileName();
        toggleEditMode(true);
        nameInput.Select();
    }
    public void confirmNameChange()
    {
        Debug.Log("confirm name change!");
        if (isFileNameEditing) {
            setFileName(nameInput.text);
        }
        else {
            if (WriteHandler.changeSongName(getName(), nameInput.text)) {
                setName(nameInput.text);
            }
            else {
                Debug.Log("EXISTS!");
            }
        }
        toggleEditMode(false);
        writeSongs();
    }
    public void cancelNameChange()
    {
        toggleEditMode(false);
    }
    public bool getActive()
    {
        return toggle.isOn;
    }
    public void setToggle(bool isActive)
    {
        toggleIsSet = false;
        toggle.isOn = isActive;
        toggleIsSet = true;
    }
    public void setActive()
    {
        if (toggleIsSet)
        {
            Debug.Log("active change!");
            writeSongs();
        }
    }
    public void goInto()
    {
        readLyrics();
    }


    private void toggleEditMode(bool isEdit)
    {
        nameInput.gameObject.SetActive(isEdit);
        nameTag.gameObject.SetActive(!isEdit);

        normalGroup.SetActive(!isEdit);
        editGroup.SetActive(isEdit);
    }
    private void writeSongs()
    {
        mngHdlr.writeSongs();
    }
    private void readLyrics()
    {
        mngHdlr.readLyrics(getName());
    }
}
