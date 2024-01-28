using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ProfilMenu : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public Image hair;
    public Image eyes;
    public Image nose;
    public Image mouth;
    public Image clothe;

    public CharacterAssets hairAssets;
    public CharacterAssets eyesAssets;
    public CharacterAssets noseAssets;
    public CharacterAssets mouthAssets;
    public CharacterAssets clotheAssets;

    public Button comeback;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        UIM = UIManager.instance;
        GM = GameManager.instance;

        SetAssets();

        comeback.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.MESSAGE_PRETENDANT); });
    }

    void SetAssets()
    {
        playerName.text = GM.matchName;
        hair.sprite = hairAssets.sprites[GM.players[GM.matchIndex].hairIndex];
        eyes.sprite = eyesAssets.sprites[GM.players[GM.matchIndex].eyesIndex];
        nose.sprite = noseAssets.sprites[GM.players[GM.matchIndex].noseIndex];
        mouth.sprite = mouthAssets.sprites[GM.players[GM.matchIndex].mouthIndex];
        clothe.sprite = clotheAssets.sprites[GM.players[GM.matchIndex].clotheIndex];
    }
}
