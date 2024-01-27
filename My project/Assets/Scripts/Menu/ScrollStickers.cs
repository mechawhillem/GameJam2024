using UnityEngine;
using UnityEngine.UI;

public class ScrollStickers : MonoBehaviour
{
    public GameObject content;
    public Transform holder;
    public HobbysAssets assets;
    public CharacterSelection characterSelection;
    UIManager UIM;

    void Start()
    {
        UIM = UIManager.instance;

        for (int i = 0; i < assets.sprites.Length; i++)
        {
            GameObject instance = Instantiate(content, holder);
            ContentInfo info = instance.GetComponent<ContentInfo>();
            info.index = i;
            info.image.sprite = assets.sprites[i];
            info.button.onClick.AddListener(delegate { 
                UIM.SetActiveMenu(MenuType.PROFIL_CREATION);
                //characterSelection.selectedImage.sprite = assets.sprites[info.index];
            });
        }
    }
}
