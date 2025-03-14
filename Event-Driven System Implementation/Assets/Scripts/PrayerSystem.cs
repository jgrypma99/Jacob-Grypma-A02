using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrayerSystem : MonoBehaviour
{
    public List<string> prayerSequence = new List<string>();
    public int maxWords = 3; //Max words in prayer
    public Text prayerText; //Display prayer in latin alphabet (placeholder)

    public void AddWordToPrayer(string word)
    {
        //if prayer has empty word slots add word to sequence
        if (prayerSequence.Count < maxWords)
        {
            prayerSequence.Add(word);
            ApplyEffects(word);
            UpdatePrayerUI();
        }
        else
        {
            Debug.Log("Prayer is full!");
        }
    }

    private void ApplyEffects(string word)
    {
        //Placeholder words and effect
        switch (word)
        {
            case "BENEDICTIO":
                Debug.Log("Benedictio effect");
                break;
            case "LACRIMA":
                Debug.Log("Lacrima effect");
                break;
            case "MARTYR":
                Debug.Log("Martyr effect");
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }

    //update the prayer in the ui
    private void UpdatePrayerUI()
    {
        prayerText.text = string.Join(" - ", prayerSequence);
    }
}
