using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatchPhraseMenu : MonoBehaviour
{
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;

    public TextMeshProUGUI selectionOne;
    public TextMeshProUGUI selectionSecond;
    public TextMeshProUGUI selectionThird;

    int tempo;

    public int indexOne;
    public int indexTwo;
    public int indexThree;

    [TextArea(3, 3)]
    public string[] phrases;
    List<int> indexPhraseTake = new List<int>();
    List<int> indexPhraseDone = new List<int>();

    UIManager UIM;
    GameManager GM;

    void Start()
    {
        UIM = UIManager.instance;
        GM = GameManager.instance;

        UIM.ChangeContexteText($"{GM.matchName} sélectionne une phrase d'accroche");

        TakeRandPhrase(selectionOne, indexOne);
        indexOne = tempo;
        TakeRandPhrase(selectionSecond, indexTwo);
        indexTwo = tempo;
        TakeRandPhrase(selectionThird, indexThree);
        indexThree = tempo;

        buttonOne.onClick.AddListener(delegate
        {
            GM.matchPhraseOne = phrases[indexOne];
            UIM.SetActiveMenu(MenuType.THE_SWIPER);
        });
        buttonTwo.onClick.AddListener(delegate
        {
            GM.matchPhraseOne = phrases[indexTwo];
            UIM.SetActiveMenu(MenuType.THE_SWIPER);
        });
        buttonThree.onClick.AddListener(delegate
        {
            GM.matchPhraseOne = phrases[indexThree];
            UIM.SetActiveMenu(MenuType.THE_SWIPER);
        });
    }

    void TakeRandPhrase(TextMeshProUGUI tmp, int index)
    {
        int rand = Random.Range(0, phrases.Length - 1);
        if (!indexPhraseTake.Contains(rand))
        {
            tempo = rand;
            indexPhraseTake.Add(rand);
            tmp.text = phrases[rand];
        }
        else
        {
            TakeRandPhrase(tmp, index);
        }
    }
}
