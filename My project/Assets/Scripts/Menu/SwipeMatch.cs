using UnityEditor.Localization.Platform.Android;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMatch : MonoBehaviour
{
    public MiniatureInfo miniature;
    public Button next;
    public Button like;

    bool state = false;

    int index = -1;

    public GameObject ButtonLike, ButtonReady;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        if (state)
        {
            TakePlayers();
        }
        else
        {
            GetRandomPlayer();
        }

        next.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.CATH_PHRASE); });
        like.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.MESSAGE_PRETENDANT); });
    }

    void TakePlayers() 
    {
        index++;
        if (!GM.players[index].isMatch)
        {
            GM.currentPlayer = GM.players[index].playerName;
            GM.currentIndexPlayer = index;
        }
        else 
        {
            TakePlayers();
        }
        
    }

    void GetRandomPlayer()
    {
        int nmbOfPlayer = GM.players.Count;
        int player = Random.Range(0, nmbOfPlayer - 1);
        miniature.playerName.text = GM.players[player].playerName;
        miniature.hair.sprite = miniature.hairAssets.sprites[GM.players[player].hairIndex];
        miniature.eyes.sprite = miniature.eyesAssets.sprites[GM.players[player].eyesIndex];
        miniature.nose.sprite = miniature.noseAssets.sprites[GM.players[player].noseIndex];
        miniature.mouth.sprite = miniature.mouthAssets.sprites[GM.players[player].mouthIndex];
        miniature.clothe.sprite = miniature.clotheAssets.sprites[GM.players[player].clotheIndex];
        UIM.ChangeContexteText($"{GM.players[player].playerName} est le match");
        GM.matchName = GM.players[player].playerName;
        GM.players[player].isMatch = true;
    }

    public void switchMode(bool state)
    {
        this.state = state;
        if (this.state)
        {
            ButtonLike.SetActive(true);
            ButtonReady.SetActive(false);
        }
        else
        {
            ButtonLike.SetActive(false);
            ButtonReady.SetActive(true);
        }
    }
}
