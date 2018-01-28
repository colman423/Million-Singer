using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHandler : MonoBehaviour {
    public GameObject rootTab;
    public GameObject preferenceTab;
    public GameObject categoryTab;
    public GameObject songTab;
    public GameObject lyricsTab;
    public GameObject lyricsContainer;
    public GameObject lyricsRawPrefab;
    public Scrollbar scrollbarVertical;


    public void createLyricsRaw()
    {
        GameObject raw = Instantiate(lyricsRawPrefab);
        raw.transform.parent = lyricsContainer.transform;

        GameObject objMinute = raw.transform.Find("Time").Find("Start Time").Find("min").gameObject;
        objMinute.GetComponent<Selectable>().Select();

        scrollbarVertical.value = 0; //TODO
    }

    public void changeToCategoryTab()
    {
        rootTab.SetActive(false);
        preferenceTab.SetActive(false);
        categoryTab.SetActive(true);
        songTab.SetActive(false);
        lyricsTab.SetActive(false);
    }
    public void changeToSongTab(string ID)
    {
        rootTab.SetActive(false);
        preferenceTab.SetActive(false);
        categoryTab.SetActive(false);
        songTab.SetActive(true);
        lyricsTab.SetActive(false);

        gameObject.GetComponent<ReadHandler>().readSongs(ID);
    }
    public void changeToLyricsTab(string ID)
    {
        rootTab.SetActive(false);
        preferenceTab.SetActive(false);
        categoryTab.SetActive(false);
        songTab.SetActive(false);
        lyricsTab.SetActive(true);
    }
    public void changeToPreferenceTab()
    {
        rootTab.SetActive(false);
        preferenceTab.SetActive(true);
        categoryTab.SetActive(false);
        songTab.SetActive(false);
        lyricsTab.SetActive(false);
    }
    public void changeToRootTab()
    {
        rootTab.SetActive(true);
        preferenceTab.SetActive(false);
        categoryTab.SetActive(false);
        songTab.SetActive(false);
        lyricsTab.SetActive(false);

    }
    public void changeToMenu(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    
}
