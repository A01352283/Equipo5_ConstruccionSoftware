using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //It appears in the inspector


//This is a class in order be able to add item giving and things like that in the future
public class Dialogue
{
    [SerializeField] List<string> lines;

    public List<string> Lines{
        get{return lines;}
    }
}
