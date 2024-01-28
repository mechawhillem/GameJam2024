using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniatureInfo : MonoBehaviour
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

    public bool isDynamic = false;
    public bool isOtherPlayer = false;
    public bool idk = false;

    private void OnEnable()
    {
        if (isDynamic && isOtherPlayer == false)
        {
            int index = GameManager.instance.matchIndex;
            hair.sprite = hairAssets.sprites[GameManager.instance.players[index].hairIndex];
            eyes.sprite = eyesAssets.sprites[GameManager.instance.players[index].eyesIndex];
            nose.sprite = noseAssets.sprites[GameManager.instance.players[index].noseIndex];
            mouth.sprite = mouthAssets.sprites[GameManager.instance.players[index].mouthIndex];
            clothe.sprite = clotheAssets.sprites[GameManager.instance.players[index].clotheIndex];
        }

        if (isDynamic && isOtherPlayer)
        {
            int index = GameManager.instance.currentIndexPlayer;
            hair.sprite = hairAssets.sprites[GameManager.instance.players[index].hairIndex];
            eyes.sprite = eyesAssets.sprites[GameManager.instance.players[index].eyesIndex];
            nose.sprite = noseAssets.sprites[GameManager.instance.players[index].noseIndex];
            mouth.sprite = mouthAssets.sprites[GameManager.instance.players[index].mouthIndex];
            clothe.sprite = clotheAssets.sprites[GameManager.instance.players[index].clotheIndex];
        }

        if (idk)
        {
            int index = GameManager.instance.idk;
            hair.sprite = hairAssets.sprites[GameManager.instance.players[index].hairIndex];
            eyes.sprite = eyesAssets.sprites[GameManager.instance.players[index].eyesIndex];
            nose.sprite = noseAssets.sprites[GameManager.instance.players[index].noseIndex];
            mouth.sprite = mouthAssets.sprites[GameManager.instance.players[index].mouthIndex];
            clothe.sprite = clotheAssets.sprites[GameManager.instance.players[index].clotheIndex];
        }

    }

}
