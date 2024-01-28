using System;
using UnityEngine;
using UnityEngine.UI;

public class GameParamMenu : MonoBehaviour
{
    public GameParam gameParamMenu;
    public GameObject miniaturePrefabs;
    public Transform minatureHolder;
    public CharacterSelection charac;
    int minPlayer = 3;

    bool isFirst = true;

    UIManager UIM;
    GameManager GM;

    [Serializable]
    public class GameParam
    {
        public Button play;
        public Button addPlayer;
    }

    void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;
        Bind();
        UIM.ChangeContexteText(GetText());
        isFirst = false;
    }

    private void OnEnable()
    {
        if (!isFirst)
        {
            UIM.ChangeContexteText(GetText());
        }
    }

    string GetText() 
    {
        if (minPlayer - GM.players.Count > 0)
        {
            gameParamMenu.play.interactable = false;
            return $"Il faut encore {minPlayer - GM.players.Count} joueurs";
        }
        else
        {
            gameParamMenu.play.interactable = true;
            return $"Vous pouvez commencer a jouer !";
        }
    }

    public void Bind() 
    {
        gameParamMenu.play.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.THE_MATCH); });
        gameParamMenu.addPlayer.onClick.AddListener(delegate { 
            UIM.SetActiveMenu(MenuType.PROFIL_CREATION);
            charac.ResetUI();
        });
    }

    public void CreatePlayer(string name, int hairIndex, int eyesIndex, int noseIndex, int mouthIndex, int clothIndex)
    {
        GameObject instance = Instantiate(miniaturePrefabs, minatureHolder);
        instance.gameObject.name = name;
        MiniatureInfo miniature = instance.GetComponent<MiniatureInfo>();
        miniature.playerName.text = name;
        miniature.hair.sprite = miniature.hairAssets.sprites[hairIndex];
        miniature.eyes.sprite = miniature.eyesAssets.sprites[eyesIndex];
        miniature.nose.sprite = miniature.noseAssets.sprites[noseIndex];
        miniature.mouth.sprite = miniature.mouthAssets.sprites[mouthIndex];
        miniature.clothe.sprite = miniature.clotheAssets.sprites[clothIndex];
    }
}
