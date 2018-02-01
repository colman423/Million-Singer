using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LyricsPlayer : MonoBehaviour {
    public AudioSource audio;
    WWW www;
    //private void OnEnable() {
    //    Play(PATH.MUSIC+ "雨季.wma");
    //}
    public void Play(string filePath) {
        StartCoroutine(StartSong(filePath));
    }
    private IEnumerator StartSong(string filePath) {
        www = new WWW(filePath);
        if (www.error != null) {
            Debug.Log("WWW ERR");
            Debug.Log(www.error);
        }
        else {
            while (!www.isDone) {
                Debug.Log("progress = " + www.progress);
                yield return new WaitForSeconds(0.5f);
            }
            Debug.Log("progress = " + www.progress);
            audio.clip = NAudioPlayer.FromMp3Data(www.bytes);
            audio.Play();
        }
    }
}
