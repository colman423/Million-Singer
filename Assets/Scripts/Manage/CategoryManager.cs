using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{
    public Text nameTag;
    public InputField nameInput;
    public GameObject btnRename;
    public GameObject btnRenameConfirm;
    public GameObject btnRenameCancel;
    public GameObject btnGointo;

    public string getCategoryName()
    {
        return nameTag.text;
    }
    public void setCategoryName(string str)
    {
        nameTag.text = str;
    }
    public void editCategoryName()
    {
        nameInput.text = getCategoryName();
        toggleEditMode(true);
        nameInput.Select();
    }
    public void confirmNameChange()
    {
        Debug.Log("confirm name change!");
        setCategoryName(nameInput.text);
        toggleEditMode(false);
        WriteHandler.writeCategory(gameObject.name, getActive(), getCategoryName());
    }
    public void cancelNameChange()
    {
        toggleEditMode(false);
    }
    void toggleEditMode(bool isEdit)
    {
        nameInput.gameObject.SetActive(isEdit);
        nameTag.gameObject.SetActive(!isEdit);

        btnRename.SetActive(!isEdit);
        btnGointo.SetActive(!isEdit);
        btnRenameConfirm.SetActive(isEdit);
        btnRenameCancel.SetActive(isEdit);
    }
    public bool getActive()
    {
        return gameObject.activeSelf;
        //TODO
    }
    public void setActive(bool value)
    {
        gameObject.SetActive(value);
        //TODO
    }
}
