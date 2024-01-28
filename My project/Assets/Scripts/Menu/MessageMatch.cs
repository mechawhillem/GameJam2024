using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageMatch : MonoBehaviour
{
    public TextMeshProUGUI matchText;
    public GameObject prefabsText;
    public ToggleGroup toogle;
    public Transform holder;
    public Button next;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        UIM.ChangeContexteText($"{GM.matchName}, a toi de choisir ta phrase favorite!");
        matchText.text = GM.matchPhraseOne;
        DisplayText();
        next.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.MESSAGE_END); });
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
