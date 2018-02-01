using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour {
    public Text text;
    public GameHandler gameHdlr;
    private string _ID;
    private Song[] _songList;

    public string ID {
        get {
            return _ID;
        }
        set {
            _ID = value;
        }
    }
    public string cateName {
        get {
            return text.text;
        }
        set {
            text.text = value;
        }
    }
    public Song[] songList { 
        get {
            return _songList;
        }
        set {
            _songList = value;
        }
    }

    public void initial(string ID, string name, Song[] songList) {
        this.ID = ID;
        this.cateName = name;
        this.songList = songList;
    }
    public void goInto() {
        gameHdlr.loadSongs(songList);
    }
}
