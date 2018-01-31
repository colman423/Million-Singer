using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsManager : MonoBehaviour {
    public TimePicker startPicker;
    public TimePicker endPicker;
    public InputField inputField;
    public void set(string start, string end, string sentence) {
        set(start, end, sentence, VOICE.NORMAL);
    }
    public void set(string start, string end, string sentence, int voice) {
        startPicker.setTime(start);
        endPicker.setTime(end);
        inputField.text = sentence;
        setVoice(voice);
    }

    public void setVoice(int voice) {
        //TODO
    }
}
