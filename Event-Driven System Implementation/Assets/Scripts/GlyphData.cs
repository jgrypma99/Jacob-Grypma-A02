using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//assign each glyph a corresponding latin letter
[CreateAssetMenu(fileName = "NewGlyph", menuName = "Word System/Glyph")]
public class GlyphData : ScriptableObject
{
    public string glyphName; //the name of the glyph
    public string correspondingLetter; //the latin letter it corresponds to
}
