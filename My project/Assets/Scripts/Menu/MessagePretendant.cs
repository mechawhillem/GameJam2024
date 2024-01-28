using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePretendant : MonoBehaviour
{
    public TextMeshProUGUI matchMessage;
    public TextMeshProUGUI pretendantMessage;
    public Button sendMessage;
    public Button profile;
    public SwipeMatch swip;
    public TMP_InputField field;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        matchMessage.text = GM.matchPhraseOne;

        sendMessage.onClick.AddListener(delegate
        {
            GM.playersRespondOne.Add(pretendantMessage.text);
            IsEnd();
        });

        profile.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.PROFIL); });
    }

    void IsEnd()
    {
        if (GM.currentIndexPlayer == GM.players.Count - 1)
        {
            swip.isEnd = true;
        }
        field.text = "";
        UIM.SetActiveMenu(MenuType.THE_SWIPER);
    }
}
