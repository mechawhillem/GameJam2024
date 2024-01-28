using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePretendant : MonoBehaviour
{
    public TextMeshProUGUI matchMessage;
    public TextMeshProUGUI pretendantMessage;
    public Button sendMessage;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        sendMessage.onClick.AddListener(delegate { 
            GM.playersRespondOne.Add(pretendantMessage.text);
            UIM.SetActiveMenu(MenuType.THE_SWIPER);
        });
    }
}
