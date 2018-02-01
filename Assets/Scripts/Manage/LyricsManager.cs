using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsManager : MonoBehaviour {
    public TimePicker startPicker;
    public TimePicker endPicker;
    public InputField inputField;

    public void setLyrics(Lyrics lyrics) {
        startPicker.setTime(lyrics.start);
        endPicker.setTime(lyrics.end);
        sentence = lyrics.sentence;
        voice = lyrics.voice;
    }
    public Lyrics getLyrics() {
        return new Lyrics(startPicker.getTimeString(), endPicker.getTimeString(), sentence, voice);
    }

    public string sentence {
        get {
            return inputField.text;
        }
        set {
            inputField.text = value;
        }
    }
    public int voice {
        get {
            return VOICE.NORMAL;
            //TODO
        }
        set {
            //TODO
        }
    }
}
