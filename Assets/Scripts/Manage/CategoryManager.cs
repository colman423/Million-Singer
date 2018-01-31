using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{
    public Text nameTag;
    public InputField nameInput;
    public Toggle togActive;
    public GameObject btnRename;
    public GameObject btnRenameConfirm;
    public GameObject btnRenameCancel;
    public GameObject btnGointo;
    public ManageHandler mngHdlr;

    bool toggleIsSet = false;
    public string getID()
    {
        return gameObject.name;
    }
    public void setID(string ID)
    {
        gameObject.name = ID;
    }
    public string getName()
    {
        return nameTag.text;
    }
    public void setName(string str)
    {
        nameTag.text = str;
    }
    public void editCategoryName()
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
        writeCates();
    }
    public void cancelNameChange()
    {
        toggleEditMode(false);
    }
    public bool getActive()
    {
        return togActive.isOn;
    }
    public void setToggle(bool isActive)
    {
        toggleIsSet = false;
        togActive.isOn = isActive;
        toggleIsSet = true;
    }
    public void setActive()
    {
        if( toggleIsSet )
        {
            Debug.Log(getID()+" toggle setting active");
            writeCates();
        }
    }
    public void goInto()
    {
        readSongs();
    }

    private void toggleEditMode(bool isEdit)
    {
        nameInput.gameObject.SetActive(isEdit);
        nameTag.gameObject.SetActive(!isEdit);

        btnRename.SetActive(!isEdit);
        btnGointo.SetActive(!isEdit);
        btnRenameConfirm.SetActive(isEdit);
        btnRenameCancel.SetActive(isEdit);
    }
    private void writeCates()
    {
        mngHdlr.writeCates();
    }
    private void readSongs()
    {
        mngHdlr.readSongs(this.getID(), this.getName());
    }
}
