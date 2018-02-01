using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public GameObject categoryTab;
    public GameObject songTab;
    public GameObject lyricsTab;
    public GameObject categoryContainer;
    public GameObject songContainer;

    // Use this for initialization
    void Start () {
        initialConfig();
        initalCategories();
    }

    void initalCategories() {
        Cate[] cateList = ReadHandler.readCategories();
        for( int i=0; i<9; i++ ) {
            CategoryButton cateBtn = categoryContainer.transform.GetChild(i).GetComponent<CategoryButton>();
            Cate cate = cateList[i];
            Song[] songList = ReadHandler.readSongs(cate.ID);
            cateBtn.initial(cate.ID, cate.name, songList);
        }
    }

    void initialConfig()
    {
        Color btnColor = new Color(0f, 142/(float)255, 224/(float)255);
        string music = "雨季.wma";
        ColorManager.setBtnColor(btnColor);
        ColorManager.setBtnDisabledColor(Color.red);
    }

    public void loadSongs(Song[] songList) {
        Debug.Log("load Songs");
        for (int i = 0; i < 9; i++) {
            SongButton songBtn = songContainer.transform.GetChild(i).GetComponent<SongButton>();
            Song song = songList[i];
            songBtn.initial(song.name, song.file);
        }
        changeToSongTab();
    }
    public void loadLyrics(string songName, string file) {

    }

    public void changeToCateTab() {
        categoryTab.SetActive(true);
        songTab.SetActive(false);

    }
    public void changeToSongTab() {
        categoryTab.SetActive(false);
        songTab.SetActive(true);
    }
    public void changeToLyricsTab() {

    }
}
