using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHandler : MonoBehaviour {
    public GameObject rootTab;
    public GameObject categoryTab;
    public GameObject songTab;
    public GameObject lyricsTab;

    public GameObject categoryContainer;
    public GameObject songContainer;
    public Text cateTitle;

    public GameObject lyricsContainer;
    public GameObject lyricsRawPrefab;
    public Scrollbar scrollbarVertical;

    void Start()
    {
        readCates();
    }
    public void readCates()
    {
        Cate[] cateList = ReadHandler.readCategories();
        for (int i = 0; i < 9; i++)
        {
            CategoryManager cateMng = categoryContainer.transform.GetChild(i).GetComponent<CategoryManager>();
            Cate cate = cateList[i];
            cateMng.setID(cate.ID);
            cateMng.setName(cate.name);
            cateMng.setToggle(cate.enabled);
        }
    }
    public void writeCates()
    {
        Cate[] cateList = new Cate[9];
        for( int i=0; i<9; i++)
        {
            CategoryManager cateMng = categoryContainer.transform.GetChild(i).GetComponent<CategoryManager>();
            cateList[i] = new Cate(cateMng.getID(), cateMng.getName(), cateMng.getActive());
        }
        WriteHandler.writeCategories(cateList);
    }
    public void readSongs(string cateID, string cateName)
    {
        changeToSongTab();
        songContainer.name = cateID;
        cateTitle.text = cateName;
        Song[] songList = ReadHandler.readSongs(cateID);
        for (int i = 0; i < 9; i++)
        {
            SongManager songMng = songContainer.transform.GetChild(i).GetComponent<SongManager>();
            Song song = songList[i];

            songMng.setName(song.name);
            songMng.setFileName(song.file);
            songMng.setToggle(song.enabled);
        }

    }
    public void writeSongs()
    {
        Song[] songList = new Song[9];
        for (int i = 0; i < 9; i++)
        {
            SongManager songMng = songContainer.transform.GetChild(i).GetComponent<SongManager>();
            songList[i] = new Song(songMng.getName(), songMng.getFileName(), songMng.getActive());
        }
        WriteHandler.writeSongs(songContainer.name, songList);
    }
    public void readLyrics(string songName)
    {
        foreach (Transform child in lyricsContainer.transform) {
            GameObject.Destroy(child.gameObject);
        }
        changeToLyricsTab();
        lyricsContainer.name = songName;

        List<Lyrics> lyricsList = ReadHandler.readLyrics(songName);
        foreach( Lyrics lyr in lyricsList)
        {
            createLyricsRaw(lyr);
        }
        if (lyricsList.Count == 0) addEmptyLyricsRaw();
    }
    public void writeLyrics() {
        List<Lyrics> lyricsList = new List<Lyrics>();
        foreach(Transform gObj in lyricsContainer.transform) {
            Lyrics lyr = gObj.GetComponent<LyricsManager>().getLyrics();
            lyricsList.Add(lyr);
        }
        string songName = lyricsContainer.name;
        WriteHandler.writeLyrics(songName, lyricsList);
    }




    public GameObject createLyricsRaw(Lyrics lyrics) {
        GameObject row = Instantiate(lyricsRawPrefab);
        row.transform.SetParent(lyricsContainer.transform);

        if (!lyrics.Equals(default(Lyrics))) {
            row.GetComponent<LyricsManager>().setLyrics(lyrics);
        }
        return row;

    }
    public void addEmptyLyricsRaw() {
        GameObject row = createLyricsRaw(default(Lyrics));
        GameObject objMinute = row.GetComponent<LyricsManager>().startPicker.iMin.gameObject;
        objMinute.GetComponent<Selectable>().Select();

        scrollbarVertical.value = 0; //TODO
    }



    public void changeToCategoryTab()
    {
        rootTab.SetActive(false);
        categoryTab.SetActive(true);
        songTab.SetActive(false);
        lyricsTab.SetActive(false);
    }
    public void changeToSongTab()
    {
        rootTab.SetActive(false);
        categoryTab.SetActive(false);
        songTab.SetActive(true);
        lyricsTab.SetActive(false);
    }
    public void changeToLyricsTab()
    {
        rootTab.SetActive(false);
        categoryTab.SetActive(false);
        songTab.SetActive(false);
        lyricsTab.SetActive(true);
    }
    public void changeToRootTab()
    {
        rootTab.SetActive(true);
        categoryTab.SetActive(false);
        songTab.SetActive(false);
        lyricsTab.SetActive(false);
    }
    public void changeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    
}
