using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageMatch : MonoBehaviour
{
    public TextMeshProUGUI matchText;
    public GameObject prefabsText;
    public ToggleGroup toogle;
    public Transform holder;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        UIM.ChangeContexteText($"{GM.matchName}, a toi de choisir !");
        matchText.text = GM.matchPhraseOne;
        DisplayText();
    }

    void DisplayText()
    {
        for (int i = 0; i < GM.players.Count - 1; i++)
        {
            GameObject instance = Instantiate(prefabsText, holder);
            instance.GetComponent<EndMessageinfo>().display.text = GM.playersRespondOne[i];
            instance.GetComponent<EndMessageinfo>().toggle.group = toogle;
        }
    }
}
