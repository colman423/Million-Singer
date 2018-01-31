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
    public void print()
    {
        Debug.Log(ID + name + enabled);
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