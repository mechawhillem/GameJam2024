using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageEnd : MonoBehaviour
{
    public TextMeshProUGUI matchtext;
    public TextMeshProUGUI pretendanttext;
    public Button next;

    UIManager UIM;
    GameManager GM;

    private void Start()
    {
        UIM = UIManager.instance;
        GM = GameManager.instance;

        matchtext.text = GM.matchPhraseOne;
        pretendanttext.text = GM.playersRepondSelect;
        UIM.ChangeContexteText("Résultat à lire a voix haute !");
        next.onClick.AddListener(delegate { UIM.ResetScene(); });
    }
}
