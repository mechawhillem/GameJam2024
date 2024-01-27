using UnityEngine;
using UnityEngine.UI;

public class SwipeMatch : MonoBehaviour
{
    public MiniatureInfo miniature;
    public Button next;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        GetRandomPlayer();
        next.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.CATH_PHRASE); });
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

    }
}
