using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores a list of valid words for use in prayers

[CreateAssetMenu(fileName = "WordList", menuName = "Word System/Word List")]
public class WordList : ScriptableObject
{
    public List<string> validWords;
}
