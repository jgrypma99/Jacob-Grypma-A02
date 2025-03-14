using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handles building words from glyphs
public class WordBuilder : MonoBehaviour
{
    public List<ItemSlots> glyphSlots; //Assign UI slots in Inspector
    public WordList wordList; //Assign the valid word list
    public PrayerSystem prayerSystem; //Assign the prayer system

    private string currentWord = "";

    public void SubmitWord()
    {
        currentWord = "";

        foreach (var slot in glyphSlots)
        {
            if (slot.transform.childCount > 0)
            {
                DraggableItem glyph = slot.transform.GetChild(0).GetComponent<DraggableItem>();
                if (glyph != null)
                {
                    currentWord += glyph.GetLetter(); //Get Latin letter
                }
            }
        }

        if (wordList.validWords.Contains(currentWord))
        {
           prayerSystem.AddWordToPrayer(currentWord);
            ClearSlots();
        }
        else
        {
            Debug.Log("Invalid Word");
        }
    }

    private void ClearSlots()
    {
        foreach (var slot in glyphSlots)
        {
            if (slot.transform.childCount > 0)
            {
                Destroy(slot.transform.GetChild(0).gameObject); //Clear glyphs
            }
        }
    }
}
