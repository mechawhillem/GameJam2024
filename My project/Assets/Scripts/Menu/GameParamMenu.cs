using System;
using UnityEngine;
using UnityEngine.UI;

public class GameParamMenu : MonoBehaviour
{
    public GameParam gameParamMenu;
    public GameObject miniaturePrefabs;
    public Transform minatureHolder;

    UIManager UIM;

    [Serializable]
    public class GameParam
    {
        public Button play;
        public Button addPlayer;
    }

    void Start()
    {
        UIM = UIManager.instance;
        Bind();
    }

    public void Bind() 
    {
        gameParamMenu.play.onClick.AddListener(delegate { });
        gameParamMenu.addPlayer.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.PROFIL_CREATION); });
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
