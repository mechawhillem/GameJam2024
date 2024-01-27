using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchPhraseMenu : MonoBehaviour
{
    public TextMeshProUGUI selectionOne;
    public TextMeshProUGUI selectionSecond;
    public TextMeshProUGUI selectionThird;

    [TextArea(3, 3)]
    public string[] phrases;
    List<int> indexPhraseTake = new List<int>();
    List<int> indexPhraseDone = new List<int>();

    void Start()
    {
        TakeRandPhrase(selectionOne);
        TakeRandPhrase(selectionSecond);
        TakeRandPhrase(selectionThird);
    }

    void TakeRandPhrase(TextMeshProUGUI tmp)
    {
        int rand = Random.Range(0, phrases.Length - 1);
        if (!indexPhraseTake.Contains(rand))
        {
            indexPhraseTake.Add(rand);
            tmp.text = phrases[rand];
        }
        else 
        {
            TakeRandPhrase(tmp);
        }
    }
}
