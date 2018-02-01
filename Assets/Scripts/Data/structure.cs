using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Cate
{
    public string ID, name;
    public bool enabled;
    public Cate(string ID, string name, bool enabled)
    {
        this.ID = ID;
        this.name = name;
        this.enabled = enabled;
    }
}
public struct Song
{
    public string name, file;
    public bool enabled;
    public Song(string name, string file, bool enabled)
    {
        this.name = name;
        this.file = file;
        this.enabled = enabled;
    }
}
public struct Lyrics
{
    public string start, end, sentence;
    public int voice;
    public Lyrics(string start, string end, string sentence, int voice)
    {
        this.start = start;
        this.end = end;
        this.sentence = sentence;
        this.voice = voice;
    }
    public void print()
    {
        Debug.Log(start + " " + end + " " + voice + " " + sentence);
    }

}
public struct VOICE
{
    public static int NORMAL = 0;
    public static int MALE = 1;
    public static int FEMALE = 2;
}