using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongButton : MonoBehaviour {
    public Text text;
    public GameHandler gameHdlr;
    private string _file;

    public string file {
        get {
            return _file;
        }
        set {
            _file = value;
        }
    }
    public string songName {
        get {
            return text.text;
        }
        set {
            text.text = value;
        }
    }

    public void initial(string songName, string file) {
        this.songName = songName;
        this.file = file;
    }
    public void goInto() {
        gameHdlr.loadLyrics(songName, file);
    }
}
